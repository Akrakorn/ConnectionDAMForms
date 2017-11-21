Imports SocketBall

Public Class ClPaddle
    Private pnlPaddle As Panel
    Private _form1 As Form1
    Private _color As Color
    Private _width As Integer
    Private _height As Integer
    Private _posX As Integer
    Private _posY As Integer

    Public Sub New(form1 As Form1, color As Color, height As Integer, width As Integer)
        _form1 = form1
        Me.Color = color
        Me.Paddle_Width = width
        Me.Paddle_Height = height

        newPaddle()
    End Sub

    Private Sub newPaddle()
        pnlPaddle = New Panel

        pnlPaddle.BackColor = _color
        pnlPaddle.Size = New Size(_width, _height)
        pnlPaddle.Location = New Point(200, 200)
        Form1.Controls.Add(pnlPaddle)
    End Sub

    Public Function PosPala(MousePoint As Point) As Point
        pnlPaddle.Location = New Point(MousePoint)
        PosX = MousePoint.X
        PosY = MousePoint.Y
    End Function

    Public Property PosX As Integer
        Get
            Return _posX
        End Get
        Set(value As Integer)
            _posX = value
        End Set
    End Property

    Public Property PosY As Integer
        Get
            Return _posY
        End Get
        Set(value As Integer)
            _posY = value
        End Set
    End Property

    Public Property Paddle_Height As Integer
        Get
            Return _height
        End Get
        Set(value As Integer)
            _height = value
        End Set
    End Property

    Public Property Paddle_Width As Integer
        Get
            Return _width
        End Get
        Set(value As Integer)
            _width = value
        End Set
    End Property

    Private Property Color As Color
        Get
            Return _color
        End Get
        Set(value As Color)
            _color = value
        End Set
    End Property

    Private Property FrmMain As Form
        Get
            Return Nothing
        End Get
        Set(value As Form)
        End Set
    End Property

    Private Property Panel As Integer
        Get
            Return Nothing
        End Get
        Set(value As Integer)
        End Set
    End Property
End Class
