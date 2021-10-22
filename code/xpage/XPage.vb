Interface IXPage
    Function Build() As String
    Function ToHtml() As String
    Property Parameter As Object
    Property id As String
    Property Title As String
End Interface

Public MustInherit Class XPage
    Implements IXPage

    Public Property Title As String = "" Implements IXPage.Title
    Public Property Id As String Implements IXPage.id
    Property Parameter As Object Implements IXPage.Parameter

    MustOverride Function Build() As String Implements IXPage.Build

    Public Function ToHtml() As String Implements IXPage.ToHtml
        Return Build()
    End Function
End Class