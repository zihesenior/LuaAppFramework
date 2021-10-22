Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Text.RegularExpressions

Public Class HttpServer

    Dim TcpServer As New TcpServer

    Dim t As New Timers.Timer(1000)

    Dim receiveTimeout As Integer = 2

    Sub New()
        AddHandler t.Elapsed, Sub()
                                  If receiveTimeout > 0 Then receiveTimeout -= 1
                              End Sub
        t.Start()
        TcpServer.TcpCommunicateHandler = Sub(communicateSocket As Socket)
                                              Dim buffer(1024 * 8) As Byte
                                              Dim request = New HttpRequest
                                              Dim readedLen As Integer ' 读取的字节数
                                              Dim stream As New MemoryStream()
                                              receiveTimeout = 2
                                              While receiveTimeout > 0
                                                  If communicateSocket.Available > 0 Then
                                                      receiveTimeout = 2
                                                      readedLen = communicateSocket.Receive(buffer) '阻塞线程直到接收到数据
                                                      If readedLen > 0 Then
                                                          stream.Write(buffer, 0, readedLen)
                                                      End If
                                                  End If
                                              End While

                                              Using b As New BinaryReader(stream)
                                                  If b.BaseStream.Length = 0 Then Return
                                                  b.BaseStream.Position = 0
                                                  If Nothing Is request.HeadLine Then request.HeadLine = HttpHelper.ReadHeadLine(b)
                                                  If Nothing Is request.Header Then request.Header = HttpHelper.ReadHeader(b)
                                                  Dim cotype = request.Header("content-type")
                                                  If Not Nothing Is cotype Then
                                                      If cotype.ToLower.StartsWith("binary/") Then
                                                          request.Body = HttpHelper.ReadToFile(b, Now.ToFileTime.ToString & cotype.ToLower.Split("/")(1))
                                                      ElseIf cotype.ToLower.StartsWith("application/x-www-form-urlencoded") Then
                                                          request.Body = Net.WebUtility.UrlDecode(Encoding.UTF8.GetString(b.ReadBytes(b.BaseStream.Length - b.BaseStream.Position)))
                                                      ElseIf cotype.ToLower.StartsWith("text/plain") Then
                                                          request.Body = Encoding.UTF8.GetString(b.ReadBytes(b.BaseStream.Length - b.BaseStream.Position))
                                                      End If
                                                  End If
                                              End Using

                                              stream.Close()

                                              Dim response = BuildeResponse(request)
                                              communicateSocket.Send(response.ToBytes)
                                              communicateSocket.Close()

                                          End Sub
    End Sub


    Private Function BuildeResponse(request As HttpRequest) As HttpResponse
        Dim content As HttpContent = If(Nothing Is HttpContentBuilder, New HttpContent, HttpContentBuilder.Build(request))
        Dim response = New HttpResponse()
        response.HeadLine = {"HTTP/1.1", content.Code, ""}
        response.Header("Date") = DateTime.Now
        response.Header("Content-Type") = String.Format("{0}", content.Type)
        response.Header("Content-Length") = If(Nothing Is content.Content, 0, content.Content.Length)
        response.Body = content.Content
        Return response
    End Function

    Public HttpContentBuilder As HttpContentBuilder

    Public Sub Start(endPoint As Integer)
        TcpServer.Start(endPoint)
    End Sub

    Public Sub Abort()
        TcpServer.Abort()
        TcpServer = Nothing
    End Sub
End Class

