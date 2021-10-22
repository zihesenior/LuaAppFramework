Imports System.IO
Imports System.Text

Public Class HttpResponse
    Public Property HeadLine As String() = {"HTTP/1.1", 200, "OK"}
    Public Property Header As New Dictionary(Of String, String)
    Public Property Body As Byte()
    Public Property OutputSreame As Stream

    Public Function ToBytes() As Byte()
        Dim sb = New StringBuilder()
        sb.AppendLine(String.Format("{0} {1} {2}", HeadLine))
        sb.Append(Header.ToString)
        sb.AppendLine() '很重要
        Using stream As New MemoryStream()
            Using writer As New BinaryWriter(stream)
                writer.BaseStream.Seek(0, SeekOrigin.Begin)
                writer.Write(Encoding.UTF8.GetBytes(sb.ToString))
                If Not Nothing Is Body Then writer.Write(Body)
                Using reader As New BinaryReader(stream)
                    reader.BaseStream.Seek(0, SeekOrigin.Begin)
                    Return reader.ReadBytes(stream.Length)
                End Using
            End Using
        End Using
    End Function

End Class
