using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameHelpers.Helpers;

namespace ConnectionDAMForms
{
    public partial class FrmMain : Form
    {

        ClPaddle Paddle;
        ClBall _ball;
        Int32 _diameter;
        List<ClBall> balls = new List<ClBall>();
        ClSocket socket = new ClSocket();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Paddle = new ClPaddle(this, Color.Red, 100, 30);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            _ball = new ClBall(Color.Aqua, "Mi pelo", 100, 110, 50, this, 100, Paddle, 250, 250, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, "");
            _ball.wallhit += pelotaGolpeadaPorPared;
            balls.Add(_ball);
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            Paddle.PosPala(Cursor.Position);
        }

        private void pelotaGolpeadaPorPared(object sender, EventArgs e)
        {
            ClBall ballHitted = (ClBall)sender;
            Ball enviarPelota = new Ball
            {
                color = ballHitted.Color.ToArgb(),
                creator = ballHitted.Owner,
                diameter = ballHitted.Diametre,
                movementX = ballHitted.MovX,
                movementY = ballHitted.MovY,
                positionY = ballHitted.PosY
            };
        }


        //    Private llBalls As New List(Of ClBall)
        //Private _ball As ClBall
        //Private Paddle As ClPaddle
        //Private Neighbour_L As ClNeighbour
        //Private Neighbour_R As ClNeighbour
        //Private random As New Random
        //Private _diameter As Integer
        //Private _leftwall As Boolean
        //Private _rightwall As Boolean

        //Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        //    If (e.KeyCode = Keys.Escape) Then
        //        Me.Close()
        //    ElseIf(e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.N) Then
        //       _diameter = random.Next(25, 80)
        //        _ball = New ClBall(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), "Name", random.Next(1, 8), random.Next(1, 8), _diameter, Me,
        //                           random.Next(30, 100), Paddle, random.Next(0, Me.Width - _diameter), random.Next(0, Me.Height - _diameter),
        //                           Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 0, Neighbour_L, Neighbour_R)
        //        llBalls.Add(_ball)
        //    End If

        //End Sub

        //Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        //    Paddle = New ClPaddle(Me, Color.Red, 100, 30)
        //    Neighbour_L = New ClNeighbour("1.1.1.1", "Manolo", False) 'izquierda no es pared
        //    Neighbour_R = New ClNeighbour("2.2.2.2", "Maria", True) 'derecha es pared
        //    Cursor.Hide()
        //End Sub

        //Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        //    Paddle.PosPala(Cursor.Position)
        //End Sub
    }
}
