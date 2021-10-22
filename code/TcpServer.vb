Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Class TcpServer

#Region "TCP"

    Dim watchSocket As Socket
    Dim socketPool As New List(Of Socket)

    Public Sub Start(endPoint As Integer)
        Try
            '点击开始监听时 在服务端创建一个负责监听IP和端口号的Socket
            watchSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            watchSocket.Bind(New IPEndPoint(IPAddress.Any, endPoint)) '绑定端口号
            watchSocket.Listen(10) '设置监听
            '创建监听线程
            Dim thread = New Thread(AddressOf Listen) With {.IsBackground = True}
            thread.Start(watchSocket)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Listen(watchSocket As Socket)
        Try
            While True
                Dim communicateSocket = watchSocket.Accept  '阻塞线程知道接收到客户端连接
                '开启一个新线程，执行接收消息方法
                Dim r_thread = New Thread(AddressOf Received) With {.IsBackground = True}
                r_thread.Start(communicateSocket)
                socketPool.Add(communicateSocket)
            End While
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Public Delegate Sub CommunicateDelegate(communicateSocket As Socket)
    Public TcpCommunicateHandler As CommunicateDelegate
    Private Sub Received(communicateSocket As Socket)
        If Nothing Is TcpCommunicateHandler Then Return
        TcpCommunicateHandler(communicateSocket)
    End Sub

    Sub Abort()
        Try
            watchSocket.Close()
            For Each i In socketPool
                i.Close()
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

#End Region
End Class
