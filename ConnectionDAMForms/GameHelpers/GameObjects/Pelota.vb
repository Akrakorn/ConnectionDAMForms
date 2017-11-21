Imports SocketBall

Public Class ClBall

    ' Constants'
    Const IntMov = 10
    Const IntTocada = 5000

    ' Var '
    Private gra As Graphics
    Private WithEvents pan As Panel
    Private _posX, _posY As Integer
    Private _color As Color
    Private _owner As String
    Private _movX As Integer
    Private _movY As Integer
    Private _diametre As Integer
    Private _frmMain As Form1
    Private _paddle As ClPaddle
    Private _interv As Integer
    Private _life As Integer
    Private _resX As Integer
    Private _resY As Integer
    Private _vel As Integer
    Private _NeighbourL As ClNeighbour
    Private _NeighbourR As ClNeighbour
    Private random As New Random()
    Private WithEvents tmMove As Timers.Timer
    Private WithEvents tmTocada As Timers.Timer

    'Private FormMain As Form, Interv As Integer, Paddle As ClPaddle, PosX As Integer, PosY As Integer, ResX As Integer, ResY As Integer, Life As String


    ' Constructor '
    Public Sub New(xColor As Color, Owner As String, movX As Integer, movY As Integer, Diametre As Integer, FormMain As Form, Interv As Integer, Paddle As ClPaddle, PosX As Integer, PosY As Integer, ResX As Integer, ResY As Integer, Life As String, NeighbourR As ClNeighbour, NeighbourL As ClNeighbour)

        _frmMain = FormMain
        _color = xColor
        _posX = PosX
        _posY = PosY
        _diametre = Diametre
        _paddle = Paddle
        _resX = ResX
        _resY = ResY
        _owner = Owner
        _movX = movX
        _movY = movY
        _NeighbourL = NeighbourL
        _NeighbourR = NeighbourR

        newBall()
        startTimers()

    End Sub

    ' Ball Creator in the Form '
    Private Sub newBall()
        _vel = 1
        pan = New Panel
        pan.BackColor = Color.Transparent
        pan.Size = New Size(_diametre, _diametre)
        pan.Location = New Point(_posX, _posY)
        _frmMain.Controls.Add(pan)

        Color = _color
    End Sub

    ' Draw circular panels '
    Private Sub panell_Paint(sender As Object, e As PaintEventArgs) Handles pan.Paint
        Dim g As Graphics
        g = pan.CreateGraphics()
        g.FillEllipse(New SolidBrush(Color), New Rectangle(0, 0, pan.Width, pan.Height))
    End Sub

    Private Sub startTimers()
        'Ball Movement Timer
        tmMove = New Timers.Timer()
        tmMove.Interval = IntMov
        tmMove.Start()

        'Ball hit the Paddle Timer
        tmTocada = New Timers.Timer()
        tmTocada.Interval = IntTocada
        tmTocada.Start()
    End Sub

    Private Sub tmMove_Tick(sender As Object, e As EventArgs) Handles tmMove.Elapsed
        Move()
    End Sub

    Public Sub Move()

        Static dx = MovX, dy = MovY

        ' Control if the ball hit the wall
        If ((PosY <= 0) Or (PosY >= (_frmMain.Height - Diametre))) Then
            dy = -dy - _vel
        End If
        If ((((PosX <= 0) And Not _NeighbourL.Wall) Or (PosX >= (_frmMain.Width - Diametre)) And Not _NeighbourR.Wall)) Then
            tmMove.Stop()
            ' travel()
            ' TRAVEL ENVIAREMOS PELOTA A OTRO AMAZING ORDENADOR

            pan.Invoke(Sub()
                           _frmMain.Controls.Remove(pan)
                       End Sub)

        ElseIf (PosX <= 0 Or PosX >= (_frmMain.Width - Diametre)) Then
            dx = -dx - _vel
        End If

        ' Control if the ball hit the paddle 
        If ((PosY >= _paddle.PosY) And (PosY <= _paddle.PosY + _paddle.Paddle_Height)) Then
            If (((PosX <= _paddle.PosX + _paddle.Paddle_Width) And (PosX > _paddle.PosX)) Or ((PosX + Diametre >= _paddle.PosX) And (PosX < _paddle.PosX + _paddle.Paddle_Width))) Then
                dx = -dx
                'choque = True
                tmTocada.Stop()
                tmTocada.Start()            ' Tornem a començar el Timer
                'RaiseEvent haRebotat(Me, EventArgs.Empty)
            End If
        End If

        If (((PosX <= _paddle.PosX + _paddle.Paddle_Width) And (PosX > _paddle.PosX)) Or ((PosX + Diametre >= _paddle.PosX) And (PosX < _paddle.PosX + _paddle.Paddle_Width))) Then
            If ((PosY + Diametre >= _paddle.PosY) And (PosY <= _paddle.PosY + _paddle.Paddle_Height) Or ((PosY + Diametre <= _paddle.PosY) And (PosY >= _paddle.PosY))) Then
                dy = -dy
                'choque = True
                tmTocada.Stop()
                tmTocada.Start()                ' Tornem a començar el Timer
                'RaiseEvent haRebotat(Me, EventArgs.Empty)
            End If
        End If

        'x = _posX + dx
        'y = _posY + dy

        PosX += dx
        PosY += dy

        ' CONTROLEM SI SURT DE LA PANTALLA
        If (PosX < 0) Then
            PosX = 0
        End If
        If (PosX > _frmMain.Width - Diametre) Then
            PosX = _frmMain.Width - Diametre
        End If
        If (PosY < 0) Then
            PosY = 0
        End If
        If (PosY > (_frmMain.Height - Diametre)) Then
            PosY = _frmMain.Height - Diametre
        End If

        pan.Invoke(Sub()
                       pan.Location = New Point(PosX, PosY)
                   End Sub)
    End Sub

    Public Sub Travel()
        ' llamar a clase Socket del Xavi
    End Sub


    Private Property PosX As Integer
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

    Public Property Diametre As Integer
        Get
            Return _diametre
        End Get
        Set(value As Integer)
            _diametre = value
        End Set
    End Property

    Public Property Color As Color
        Get
            Return _color
        End Get
        Set(value As Color)
            _color = value
        End Set
    End Property

    Public Property MovX As Integer
        Get
            Return _movX
        End Get
        Set(value As Integer)
            _movX = value
        End Set
    End Property

    Public Property MovY As Integer
        Get
            Return _movY
        End Get
        Set(value As Integer)
            _movY = value
        End Set
    End Property

    Public Property Interv As Integer
        Get
            Return _interv
        End Get
        Set(value As Integer)
            _interv = value
        End Set
    End Property

    Public Property Life As Integer
        Get
            Return _life
        End Get
        Set(value As Integer)
            _life = value
        End Set
    End Property

    Public Property ResX As Integer
        Get
            Return _resX
        End Get
        Set(value As Integer)
            _resX = value
        End Set
    End Property

    Public Property ResY As Integer
        Get
            Return _resY
        End Get
        Set(value As Integer)
            _resY = value
        End Set
    End Property

    Public Property Owner As String
        Get
            Return _owner
        End Get
        Set(value As String)
            _owner = value
        End Set
    End Property

    Public Property Paddle As ClPaddle
        Get
            Return _paddle
        End Get
        Set(value As ClPaddle)
            _paddle = value
        End Set
    End Property



End Class
