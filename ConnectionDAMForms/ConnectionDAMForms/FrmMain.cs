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

namespace ConnectionDAMForms
{
    public partial class FrmMain : Form
    {
        ClSocket socket = new ClSocket();
        ClSocket socket2 = new ClSocket();
        ClientConnection _serverConnection = new ClientConnection();
        const String ServerURL = "http://localhost:3000";

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
            socket2.msgReceived += Socket_msgReceived;
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
            socket2.connectSocketListener(cbIPLocal.Text);
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
                    _serverConnection = new ClientConnection();
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
            String data = String.Format("Message received from Server: {0}", sender.ToString());
            MessageBox.Show(data);

            // Interoperar con la clase ClSocket Local

        }

        private void PositionConfirmed(object sender, EventArgs e)
        {
            String data = String.Format("Message received from Server: {0}", sender.ToString());
            MessageBox.Show(data);

            // Interoperar con la clase ClSocket Local

        }

        private void ShowGameInfo(object sender, EventArgs e)
        {
            String data = String.Format("Message received from Server: {0}", sender.ToString());
            MessageBox.Show(data);
        }

        public void disconnectSocketServer()
        {
            _serverConnection.disconnectSocketServer();
        }

    }
}
