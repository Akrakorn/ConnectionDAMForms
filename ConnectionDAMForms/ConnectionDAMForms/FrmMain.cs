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
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {            
            /*
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    tbIPLocal.Text = ip.ToString();
                }
            }
            */
            
        }

        private void btConectar_Click(object sender, EventArgs e)
        {

        }

        private void btEscuchar_Click(object sender, EventArgs e)
        {
            ClSocket socket = new ClSocket();

            socket.connectSocketListener(tbIPLocal.Text);
        }
    }
}
