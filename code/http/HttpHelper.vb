Imports System.IO
Imports System.Text

Public Class HttpHelper


    Public Shared Function ReadHeadLine(reader As BinaryReader) As String()
        Dim headline As String() = Nothing
        Dim rnspliter = {Char.MinValue, Char.MinValue}
        Dim StrBuilder As New StringBuilder
        While reader.BaseStream.Position < reader.BaseStream.Length
            Dim c = reader.ReadChar
            StrBuilder.Append(c)
            rnspliter(0) = rnspliter(1) : rnspliter(1) = c
            Dim str As String = rnspliter
            If str = vbCrLf Then
                Dim line = StrBuilder.ToString() : StrBuilder.Clear()
                headline = line.Trim.Split(" ")
                Exit While
            End If
        End While
        Return headline
    End Function

    Shared Function ReadHeader(reader As BinaryReader) As Dictionary(Of String, String)
        Dim header As New Dictionary(Of String, String)
        Dim rnspliter = {Char.MinValue, Char.MinValue}
        Dim StrBuilder As New StringBuilder
        While reader.BaseStream.Position < reader.BaseStream.Length
            Dim c = reader.ReadChar
            StrBuilder.Append(c)
            rnspliter(0) = rnspliter(1) : rnspliter(1) = c
            Dim str As String = rnspliter
            If str = vbCrLf Then
                Dim line = StrBuilder.ToString() : StrBuilder.Clear()
                If String.IsNullOrWhiteSpace(line) Then Exit While
                Dim kv = line.Split(":")
                header(kv.FirstOrDefault.ToLower.Trim) = kv.LastOrDefault.Trim
            End If
        End While
        Return header
    End Function


    Shared Function ReadToFile(reader As BinaryReader, filepathTowww As String) As String
        Dim path As String = $"{App.CurPath}\{filepathTowww}"
        Using stream As Stream = File.Create(path, 1024 * 8)
            While reader.BaseStream.Position < reader.BaseStream.Length
                Dim buffer = reader.ReadBytes(1024 * 8)
                stream.Write(buffer, 0, buffer.Length)
            End While
        End Using
        Return path
    End Function
End Class
