
Public Class Queue(Of T)
    Inherits ArrayList

    Public Property MaxCount As Integer = Integer.MaxValue
    Public Property MinCount As Integer = Integer.MaxValue

    Public Overloads Function Enqueue(item As T) As T
        Add(item)
        Do While Count > MaxCount
            Flush()
        Loop
    End Function

    Public Overloads Function Enqueue(items As IEnumerable(Of T)) As IEnumerable(Of T)
        AddRange(items)
        Do While Count > MaxCount
            Flush()
        Loop
        Return items
    End Function

    Public Overloads Function Dequeue() As T
        If Count > 0 Then
            Dim item = Me(0)
            RemoveAt(0)
        End If
    End Function

    Public Overloads Function Dequeue(count As Integer) As T
        RemoveRange(0, count)
    End Function

    Delegate Sub FlushDelegate(e As IEnumerable(Of T))
    Public FlushHandler As FlushDelegate = Sub(e)

                                           End Sub


    Public Function Flush() As Integer
        Dim c = If(Count > MinCount, Count - MinCount, 0)
        Dim a(c) As T
        CopyTo(0, a, 0, c)
        FlushHandler(a)
        RemoveRange(0, c)
        Return c
    End Function

    Public Overloads Function Contains(items As IEnumerable(Of T)) As Boolean
        Return IndexOf(items) >= 0
    End Function

    Friend Overloads Function IndexOf(items As IEnumerable(Of T)) As Integer
        If Nothing Is Me OrElse Nothing Is items OrElse Count = 0 OrElse items.Count = 0 OrElse Count < items.Count Then
            Return -1
        End If
        Dim i = 0, j = 0
        While True
            If i < 0 Then Exit While
            i = BinarySearch(i, Count - i, Item(0), Nothing)
            For j = 1 To items.Count - 1
                If Not Me(i + j).Equals(items(j)) Then
                    Exit For
                End If
            Next
            If j = items.Count Then
                Return i
            End If
        End While

        Return -1
    End Function

End Class
