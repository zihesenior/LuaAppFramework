Imports System.IO
Imports System.Net.Http

Public Interface WebContentBuilder
    Function Build(e As String) As Object
End Interface

Public Class WebContentBuilderSelector
    Implements WebContentBuilder
    Dim ContentBuilder As WebContentBuilder
    Public Function Build(e As String) As Object Implements WebContentBuilder.Build
        Dim path = e
        Dim index = path.IndexOf("?")
        If index >= 0 Then path = path.Remove(index)
        index = path.IndexOf("#")
        If index >= 0 Then path = path.Remove(index)
        Dim ex = CStr(path.Skip(path.LastIndexOf(".")).ToArray)
        If {".xdata"}.Contains(ex) Then
            ContentBuilder = New XPageWebContentBuilder
        ElseIf {".luadata"}.Contains(ex) Then
            ContentBuilder = New LuaWebContentBuilder
        Else
            ContentBuilder = New StaticWebContentBuilder
        End If
        Return ContentBuilder.Build(e)
    End Function
End Class

Public Class StaticWebContentBuilder
    Implements WebContentBuilder

    Public Function Build(e As String) As Object Implements WebContentBuilder.Build
        Dim path = $"{App.CurPath}{e}"
        Dim content As String
        If File.Exists(path) Then
            content = File.ReadAllText(path)
        Else
            content = "404"
        End If
        Return content
    End Function
End Class

Public Class XPageWebContentBuilder
    Implements WebContentBuilder
    Dim Pages As Dictionary(Of String, Type)
    Public Function Build(e As String) As Object Implements WebContentBuilder.Build
        Dim path = e.Split(".").First
        Dim allPages = FindAllXPages().ToList
        allPages.Remove(GetType(XPage))
        Pages = allPages.ToDictionary(Function(i) CStr(i.FullName.SkipWhile((Function(c) Not c = "."c)).ToArray).Trim(".").ToLower)
        If Pages.Keys.Contains(path.ToLower) Then
            Dim xpage As IXPage = Activator.CreateInstance(Pages(path.ToLower))
            If e.Contains("?") Then xpage.Parameter = e.Substring(e.IndexOf("?") + 1)
            Return xpage.ToHtml
        Else
            Return "404"
        End If
    End Function

    Private Function FindAllXPages() As Type()
        Return AppDomain.CurrentDomain.GetAssemblies().SelectMany(Function(a) a.GetTypes().Where(Function(t) t.GetInterfaces().Contains(GetType(IXPage)))).ToArray()
    End Function

End Class


Public Class LuaWebContentBuilder
    Implements WebContentBuilder

    Public Function Build(e As String) As Object Implements WebContentBuilder.Build
        Dim path As String
        If e.Contains("?") Then
            path = $"{App.CurPath}{e.Remove(e.IndexOf("?"))}"
            Dim u As NLua.LuaTable = LuaMoudle.Current.Dostring("Parameter ={}  return Parameter")
            u.Item("data") = e.Substring(e.IndexOf("?") + 1)
        Else
            path = $"{App.CurPath}{e}"
            LuaMoudle.Current.Dostring("Parameter = null return null")
        End If
        Dim content As String
        If File.Exists(path) Then
            content = LuaMoudle.Current.Dofile(path)
        Else
            content = "404"
        End If
        Return content
    End Function

End Class

