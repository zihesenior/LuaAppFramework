Imports System.IO
Imports System.Net

Public Interface HttpContentBuilder
    Function Build(request As HttpRequest) As HttpContent
End Interface

Public Class ContentBuilderSelector
    Implements HttpContentBuilder
    Dim ContentBuilder As HttpContentBuilder
    Public Function Build(request As HttpRequest) As HttpContent Implements HttpContentBuilder.Build
        Dim path = request.HeadLine(1)
        Dim index = path.IndexOf("?")
        If index >= 0 Then path = path.Remove(index)
        index = path.IndexOf("#")
        If index >= 0 Then path = path.Remove(index)
        Dim ex = CStr(path.Skip(path.LastIndexOf(".")).ToArray)
        If {".xpage"}.Contains(ex) Then
            ContentBuilder = New XPageContentBuilder
        Else
            ContentBuilder = New StaticContentBuilder
        End If
        Return ContentBuilder.Build(request)
    End Function
End Class

Public Class StaticContentBuilder
    Implements HttpContentBuilder

    Public Function Build(request As HttpRequest) As HttpContent Implements HttpContentBuilder.Build
        Dim path = $"{App.CurPath}" & WebUtility.UrlDecode(request.HeadLine(1))
        Dim content = New HttpContent
        If File.Exists(path) Then
            content.Code = 200
            If path.EndsWith(".html") Then
                content.Type = "text/html;charset=UTF-8"
            ElseIf path.EndsWith(".xml") Then
                content.Type = "text/xml;charset=UTF-8"
            ElseIf path.EndsWith(".css") Then
                content.Type = "text/css;charset=UTF-8"
            ElseIf path.EndsWith(".map") Then
                content.Type = "text/javascript;charset=UTF-8"
            ElseIf path.EndsWith(".js") Then
                content.Type = "text/javascript;charset=UTF-8"
            ElseIf path.EndsWith(".jpg") Then
                content.Type = "image/ipeg"
            ElseIf path.EndsWith(".png") Then
                content.Type = "image/png"
            Else
                content.Type = ""
            End If

            If content.Type.StartsWith("text") Then
                content.Content = Text.Encoding.UTF8.GetBytes(File.ReadAllText(path))
            Else
                content.Content = File.ReadAllBytes(path)
                'Using stream As New FileStream(path, FileMode.Open, FileAccess.Read)
                '    Using reader As New BinaryReader(stream)
                '        reader.BaseStream.Seek(0, SeekOrigin.Begin)
                '        content.Content = reader.ReadBytes(Convert.ToInt32(stream.Length.ToString()))
                '    End Using
                'End Using
            End If
        Else
            content.Code = 404
        End If
        Return content
    End Function
End Class

Public Class XPageContentBuilder
    Implements HttpContentBuilder
    Dim Pages As Generic.Dictionary(Of String, Type)
    Public Function Build(request As HttpRequest) As HttpContent Implements HttpContentBuilder.Build
        Dim path = request.HeadLine(1).Split(".").First
        Dim allPages = FindAllXPages().ToList
        allPages.Remove(GetType(XPage))
        Pages = allPages.ToDictionary(Function(i) CStr(i.FullName.SkipWhile((Function(c) Not c = "."c)).ToArray).Replace(".", "/").ToLower)
        If Pages.Keys.Contains(path.ToLower) Then
            Dim xpage As IXPage = Activator.CreateInstance(Pages(path.ToLower))
            xpage.Request = request
            Return New HttpContent With {.Content = Text.Encoding.UTF8.GetBytes(xpage.ToHtml)}
        Else
            Return New HttpContent With {.Code = 404}
        End If
    End Function

    Private Function FindAllXPages() As Type()
        Return AppDomain.CurrentDomain.GetAssemblies().SelectMany(Function(a) a.GetTypes().Where(Function(t) t.GetInterfaces().Contains(GetType(IXPage)))).ToArray()
    End Function

End Class

