Public Class add
    Inherits XPage

    Public Overrides Function Build() As String
        If Not Nothing Is Parameter Then
            Dim j = fastJSON.JSON.Parse(Parameter)
            add(Date.Parse(j("date")), j("event"))
            Return "ok"
        Else
            Return "error"
        End If
    End Function

    Sub add(d As Date, e As String)
        Dim sh = New BasicRedis.RedisClient("127.0.0.1", 7369)
        sh.Auth("zihesenior")
        sh.HashSet("BigEvent", d.ToString("yyyy-MM-dd"), e)
    End Sub
End Class
