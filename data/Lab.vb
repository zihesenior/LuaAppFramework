Imports System.IO

Public Class Lab
    Inherits XPage

    Public Overrides Function Build() As String
        Dim fs = Directory.GetFiles($"{App.CurPath}").Select(Function(i)
                                                                 Dim filename = i.Substring(i.LastIndexOf("\") + 1)
                                                                 Return New With {
                                                                                    .path = $"{App.CurPath}{filename}",
                                                                                    .duration = filename.Split(".").First.Split("-").Last}
                                                             End Function)
        Return fastJSON.JSON.ToJSON(fs, New fastJSON.JSONParameters With {.EnableAnonymousTypes = True})
    End Function
End Class
