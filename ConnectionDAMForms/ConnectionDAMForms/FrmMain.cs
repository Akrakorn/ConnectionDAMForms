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

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

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
    }
}
