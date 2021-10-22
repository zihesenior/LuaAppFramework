Public Interface IHttpContent
    Property Type As String
    Property Code As Integer

End Interface
Public Class HttpContent
    Property Type As String = "text/html;charset=UTF-8"
    Property Code As Integer = 200
    Property Content As Byte()
End Class
Public Class UrlEncodedHttpContent
    Implements IHttpContent
    Public Property Type As String = "text/html;charset=UTF-8" Implements IHttpContent.Type
    Public Property Code As Integer = 200 Implements IHttpContent.Code
    Public Property Content As String()

End Class

'Public Class MultipartDataHttpContent
'    Implements IHttpContent
'    Public Property Type As String = "text/html;charset=UTF-8" Implements IHttpContent.Type
'    Public Property Code As Integer = 200 Implements IHttpContent.Code
'    Public Property Content As List(Of IHttpContent)
'End Class

Public Class PlainTextHttpContent
    Implements IHttpContent
    Public Property Type As String = "text/html;charset=UTF-8" Implements IHttpContent.Type
    Public Property Code As Integer = 200 Implements IHttpContent.Code
    Public Property Content As String
End Class

Public Class BinaryHttpContent
    Implements IHttpContent
    Public Property Type As String = "text/html;charset=UTF-8" Implements IHttpContent.Type
    Public Property Code As Integer = 200 Implements IHttpContent.Code
    Public Property Content As Byte()

End Class