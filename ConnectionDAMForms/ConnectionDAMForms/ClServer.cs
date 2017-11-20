using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quobject.SocketIoClientDotNet.Client;

namespace ConnectionDAMForms
{
    class ClServer
    {
        public Quobject.SocketIoClientDotNet.Client.Socket socketServer;

        public event EventHandler gameInfo;
        public event EventHandler neighborChange;
        public event EventHandler positionConfirmed;

        private String dataGameInfo
        {
            get { return dataGameInfo; }
            set { dataGameInfo = value; }
        }


        private String dataNeighborChange
        {
            get { return dataNeighborChange; }
            set { dataNeighborChange = value; }
        }


        private String dataPositionConfirmed
        {
            get { return dataPositionConfirmed; }
            set { dataPositionConfirmed = value; }
        }


        public Boolean connectSocketServer(String host)
        {
            Boolean done = false;

            if (host != "")
            {
                try
                {
                    socketServer = IO.Socket(host);
                    done = true;

                    socketServer.On("gameInfo", (infoPartida) =>
                    {
                        dataGameInfo = (String)infoPartida;
                        Console.WriteLine("gameInfo");
                        gameInfo(this, EventArgs.Empty);
                    });

                    socketServer.On("neighborChange", (data) =>
                    {
                        dataNeighborChange = (String)data;
                        Console.WriteLine("neighborChange");
                        neighborChange(this, EventArgs.Empty);
                    });

                    socketServer.On("positionConfirmed", (data) =>
                    {
                        dataPositionConfirmed = (String)data;
                        Console.WriteLine("positionConfirmed");
                        positionConfirmed(this, EventArgs.Empty);
                    });


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

        public void selectPosition(String oldList, int newPosition)
        {
            String data;
            //Datos en forma de Json
            data = "";
            socketServer.Emit("selectPosition", data);
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