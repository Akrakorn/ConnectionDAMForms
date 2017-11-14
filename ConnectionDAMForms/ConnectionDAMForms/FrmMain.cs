using ConnectionDam;
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
            ClSocket socket = new ClSocket();
            /*
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    //return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");

            //socket.connectSocketListener();*/
        }

        private void btConectar_Click(object sender, EventArgs e)
        {

        }
    }
}
