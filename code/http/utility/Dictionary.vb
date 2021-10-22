Imports System.Text

Public Class Dictionary(Of TKey, TValue)
    Inherits Generic.Dictionary(Of TKey, TValue)

    Default Public Overloads Property Item(key As TKey) As TValue
        Get
            If ContainsKey(key) Then
                Return MyBase.Item(key)
            Else
                Return Nothing
            End If
        End Get
        Set(value As TValue)
            If ContainsKey(key) Then
                MyBase.Item(key) = value
            Else
                Add(key, value)
            End If
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim sb = New StringBuilder()
        For Each i In Keys
            sb.AppendLine(String.Format("{0}:{1}", i, Item(i)))
        Next
        Return sb.ToString
    End Function
End Class