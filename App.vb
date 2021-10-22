Imports System.Reflection
Public Class App

    Public Shared CurPath As String = ""

    Private Shared _logs As New Queue(Of String)
    Public Shared ReadOnly Property Logs As String()
        Get
            Return _logs.ToArray
        End Get
    End Property
    Public Shared Sub WriteLog(log As String)
        _logs.Enqueue(log)
        If _logs.Count > 100 Then
            _logs.Dequeue()
        End If
    End Sub

    Public Shared Sub Start(Optional wwwPath As String = "")
        If IO.Directory.Exists(wwwPath) Then
            CurPath = wwwPath
        Else
            Dim exepath = Assembly.GetExecutingAssembly().Location
            CurPath = exepath.Remove(exepath.LastIndexOf("\")) & "\www\"
        End If
    End Sub
End Class