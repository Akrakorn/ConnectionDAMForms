Public Class ClError
    Private Property ID As Integer
        Get
            Return Nothing
        End Get
        Set(value As Integer)
        End Set

    End Property

    Private Property Msg As String
        Get
            Return Nothing
        End Get
        Set(value As String)
        End Set
    End Property

    Public Sub ShowError(ID As Integer)

    End Sub

    Public Sub ClError(ID As Integer, Msg As String)

    End Sub
End Class
