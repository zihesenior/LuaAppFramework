Imports System.Text
Imports NLua

Public Class LuaMoudle

    Public Shared Current As New LuaMoudle
    Sub New()
        lua.State.Encoding = Encoding.UTF8
        'lua.LoadCLRPackage()
        lua.RegisterFunction("print", Me, Me.GetType.GetMethod("print"))
        lua.RegisterFunction("Print", Me, Me.GetType.GetMethod("print"))
        lua.RegisterFunction("redisKeys", Me, Me.GetType.GetMethod("redisKeys"))
    End Sub

    Dim lua As Lua = New Lua
    Public Function Dofile(la As String) As String

        Console.WriteLine(la)
        Dim s = lua.DoFile(la) '.FirstOrDefault
        'lua.DoString(la)
        Return s.FirstOrDefault.ToString
    End Function
    Public Function Dostring(lc As String) As Object
        Return lua.DoString(lc)(0)
    End Function


#Region "For Lua"
    Sub print(s)
        Debug.WriteLine(s)
    End Sub

    Function redisKeys(p As String) As LuaTable
        'Dim xa = XDocument.Load(Server.MapPath("~/Assets/event/2016.xml"))...<event>
        Dim rc As New BasicRedis.RedisClient("150.129.138.116", 7369)
        rc.Auth("ac123456")
        Dim re = rc.Keys(p)
        Dim dic As LuaTable = lua.DoString("return {}")(0)
        If Not Nothing Is re And re.count > 1 Then
            For i = 0 To re.count - 1
                ' dic.Add(re(2 * i), re(2 * i + 1))
                dic.Item(i + 2) = re(i)
            Next
        End If
        dic.Item("me") = lua.DoString("return {by = 'ziheculture.com',conect='a@zc'}")(0)
        Return dic

    End Function
#End Region

End Class
