using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameHelpers.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectionDAMForms
{
    public partial class FrmMain : Form
    {
        private ClSocket socket = new ClSocket();
        public ClNeighbor leftNeighbor, rightNeighbor;
        public ClGameInfo gameInfo;
        public event EventHandler gameInfoReceived, positionConfirmed, changeNeighbor;
        private ServerConnection _serverConnection = new ServerConnection();
        private const String ServerURL = "http://localhost:3000";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            connectSocketServer(ServerURL);

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    cbIPLocal.Items.Add(ip.ToString());
                }
            }

            socket.msgReceived += Socket_msgReceived;
        }

        private void Socket_msgReceived(object sender, EventArgs e)
        {
            MessageBox.Show(socket.data);
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            if (socket.connectSocketLeft(tbIzquierda.Text))
            {
                MessageBox.Show("Left PC has been connected succesfully.");
            }
            if (socket.connectSocketRight(tbDerecha.Text))
            {
                MessageBox.Show("Right PC has been connected succesfully.");
            }
        }

        private void btEscuchar_Click(object sender, EventArgs e)
        {
            socket.connectSocketListener(cbIPLocal.Text);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.disconnectSocketListener();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            socket.sendDataLeft(tbEnviar.Text);
            socket.sendDataRight(tbEnviar.Text);
        }

        private Boolean connectSocketServer(String host)
        {
            Boolean done = false;

            if (host != "")
            {
                try
                {
                    _serverConnection = new ServerConnection();
                    _serverConnection.connectSocketServer(host);
                    _serverConnection.gameInfo += ShowGameInfo;
                    _serverConnection.positionConfirmed += PositionConfirmed;
                    _serverConnection.neighborChange += NeighborChanged;
                    done = true;
                }
                catch (Exception e)
                {
                    ClErrors.reportError(e.Message);
                }
            }
            else ClErrors.reportError("Can't connect socket is empty!");

            return done;
        }

        private void NeighborChanged(object sender, EventArgs e)
        {
            ClNeighbor newNeighbor;

            try
            {
                // Interoperar con la clase ClSocket Local
                newNeighbor = JsonConvert.DeserializeObject<ClNeighbor>(sender.ToString());

                if (newNeighbor.pos == "D")
                {
                    socket.connectSocketRight(newNeighbor.cliente.Ip);
                    rightNeighbor = newNeighbor;
                    changeNeighbor(rightNeighbor, EventArgs.Empty);
                }
                else
                {
                    socket.connectSocketLeft(newNeighbor.cliente.Ip);
                    leftNeighbor = newNeighbor;
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }
        }

        private void PositionConfirmed(object sender, EventArgs e)
        {
            try
            {
                positionConfirmed("", EventArgs.Empty);
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }         
        }

        private void ShowGameInfo(object sender, EventArgs e)
        {
            ClGameInfo tempGameInfo;

            try
            {
                tempGameInfo = JsonConvert.DeserializeObject<ClGameInfo>(sender.ToString());

                gameInfo = tempGameInfo;
                gameInfoReceived(gameInfo, EventArgs.Empty);
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.Message);
            }
        }

        public void disconnectSocketServer()
        {
            _serverConnection.disconnectSocketServer();
        }

    }
}
