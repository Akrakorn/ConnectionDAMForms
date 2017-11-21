Imports SocketBall

Namespace GameHelpers
    Public Class ClNeighbour

        Private _ip As String
        Private _name As String
        Private _wall As Boolean

        Public Sub New(ipx As String, namex As String, wallx As Boolean)
            Ip = ipx
            Name = namex
            wall = wallx
        End Sub

        Public Property Ip As String
            Get
                Return _ip
            End Get
            Set(value As String)
                _ip = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public Property wall As Boolean
            Get
                Return _wall
            End Get
            Set(value As Boolean)
                _wall = value
            End Set
        End Property
    End Class
End Namespace

