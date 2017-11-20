using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Quobject.SocketIoClientDotNet.Client;

namespace ConnectionDAMForms
{
    class ClSocket
    {
        const int MAX_BUFFER = 4096;


        private TcpClient socketLeft;           
        private TcpClient socketRight;

        private TcpListener socketListener;
        private Thread listenerThread;
        private Thread listenerThread1;
        private Thread listenerThread2;
        private TcpClient socketClientListener;
        private TcpClient socketClientListener1;

        public Quobject.SocketIoClientDotNet.Client.Socket socketServer;

        public delegate void delegat();

        private string _data;
        public String data{
            get { return _data; }
            set
            {
                if (value != "")
                    _data = value;
            }
        }


        public event EventHandler msgReceived;

        public ClSocket()
        {
            socketLeft = new TcpClient();
            socketRight = new TcpClient();
        }

        public Boolean connectSocketLeft(String neighborIp)
        {
            Boolean done = false;
            int portTalker;
            try
            {                
                if (socketLeft != null)
                {
                    portTalker = ClPort.GeneratePorts(neighborIp);
                    disconnectSocketLeft();                    
                    socketLeft.Connect(neighborIp, portTalker);
                    done = true;
                }
                else
                {
                    socketLeft = new TcpClient();
                    connectSocketLeft(neighborIp);
                }
            }
            catch (Exception e)
            {
                ClErrors.reportError(e.Message);
            }
            return done;
        }

        public Boolean connectSocketRight(String neighborIp)
        {
            Boolean done = false;
            int portTalker;
            try
            {
                if (socketRight != null)
                {
                    portTalker = ClPort.GeneratePorts(neighborIp);
                    disconnectSocketRight();
                    socketRight.Connect(neighborIp, portTalker);
                    done = true;
                }
                else
                {
                    socketRight = new TcpClient();
                    connectSocketRight(neighborIp);
                }
            }
            catch (Exception e)
            {
                ClErrors.reportError(e.Message);
            }
            return done;
        }

        public Boolean connectSocketListener(String yourIpString)
        {
            Boolean done = false;
            try
            {
                socketListener = new TcpListener(IPAddress.Any, ClPort.GeneratePorts(yourIpString));
                socketListener.Start();
                listenerThread = new Thread(listen);
                listenerThread.Start();
                done = true;
            }
            catch (Exception e)
            {
                ClErrors.reportError(e.Message);
            }

            return done;
        }

        private void disconnectSocketLeft()
        {
            if (socketLeft.Connected)
                socketLeft.Close();
        }

        private void disconnectSocketRight()
        {
            if (socketRight.Connected)
                socketRight.Close();
        }

        public void disconnectSocketListener()
        {
            if(socketListener != null) // asd
            {
                socketListener.Stop();
                listenerThread.Abort();
            }

        }

        public void sendDataLeft(String data)
        {
            if (socketLeft.Connected)
            {
                if (data != "")
                {
                    if (socketLeft.GetStream().CanWrite)
                    {
                        try
                        {
                            socketLeft.GetStream().Write(Encoding.Default.GetBytes(data), 0, data.Length);
                        }
                        catch (Exception e)
                        {
                            ClErrors.reportError(e.Message);
                        }
                    }
                    else ClErrors.reportError("I can't write to the socketLeft.");
                }
                else ClErrors.reportError("Empty string.");
            }
            else ClErrors.reportError("Socket not connected.");
        }

        public void sendDataRight(String data)
        {
            if (socketRight.Connected)
            {
                if (data != "")
                {
                    if (socketRight.GetStream().CanWrite)
                    {
                        try
                        {
                            socketRight.GetStream().Write(Encoding.Default.GetBytes(data), 0, data.Length);
                        }
                        catch (Exception e)
                        {
                            ClErrors.reportError(e.Message);
                        }
                    }
                    else ClErrors.reportError("I can't write to the socketRight.");
                }
                else ClErrors.reportError("Empty string.");
            }
            else ClErrors.reportError("Socket not connected.");

        }

        public Boolean connectSocketServer(String host)
        {
            Boolean done = false;

            if (host!="")
            {
                try
                {
                    socketServer = IO.Socket(host);
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

        public void disconnectSocketServer()
        {
            socketServer.Disconnect();
        }

        private void listen()
        {
            byte[] xBuffer = new byte[MAX_BUFFER];

            do
            {
                if(socketListener != null)
                {
                    if (socketClientListener == null || !socketClientListener.Connected)
                    {
                        socketClientListener = socketListener.AcceptTcpClient();
                        listenerThread1 = new Thread(listenClient1);
                        listenerThread1.Start();
                    }
                    else
                    {
                        if (socketClientListener1 == null || !socketClientListener1.Connected && socketClientListener != socketListener.AcceptTcpClient())
                        {
                            socketClientListener1 = socketListener.AcceptTcpClient();
                            listenerThread2 = new Thread(listenClient2);
                            listenerThread2.Start();
                        }
                    }
                    
                    
                }               
            } while (socketClientListener == null||!socketClientListener.Connected || socketClientListener1 == null|| !socketClientListener1.Connected);            
        }

        private void listenClient1()
        {
            byte[] xBuffer = new byte[MAX_BUFFER];
            while (socketClientListener.Connected)
            {
                if (socketClientListener.GetStream().Read(xBuffer, 0, xBuffer.Length) != 0)
                {
                    data = Encoding.Default.GetString(xBuffer, 0, xBuffer.Length);
                    msgReceived(this, EventArgs.Empty);
                    xBuffer = new byte[MAX_BUFFER];
                }
            }
        }

        private void listenClient2()
        {
            byte[] xBuffer = new byte[MAX_BUFFER];
            while (socketClientListener1.Connected)
            {
                if (socketClientListener1.GetStream().Read(xBuffer, 0, xBuffer.Length) != 0)
                {
                    data = Encoding.Default.GetString(xBuffer, 0, xBuffer.Length);
                    msgReceived(this, EventArgs.Empty);
                    xBuffer = new byte[MAX_BUFFER];
                }
            }
        }

        /*
         ClSocket.connectSocketServer("");

            ClSocket.socketServer.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("Connected to the socket");
                var text = new { text = "Hello World Server" };
                string json = JsonConvert.SerializeObject(text);
                ClSocket.socketServer.Emit("helloServer", json);
            });

            ClSocket.socketServer.On("helloClient", (data) =>
            {
                var text = new { text = "" };
                var t = JsonConvert.DeserializeAnonymousType((string)data, text);
                Console.WriteLine(t.text);
            });

            Console.ReadLine();
         */

    }
}
