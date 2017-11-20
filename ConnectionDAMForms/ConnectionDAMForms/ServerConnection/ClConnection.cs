using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quobject.SocketIoClientDotNet.Client;

namespace ConnectionDAMForms
{
    public class ClientConnection
    {
        public Quobject.SocketIoClientDotNet.Client.Socket socketServer;

        public event EventHandler gameInfo;
        public event EventHandler neighborChange;
        public event EventHandler positionConfirmed;
        private String _returnedFromServer = "";


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
                        _returnedFromServer = infoPartida.ToString();
                        Console.WriteLine("gameInfo");
                        gameInfo(_returnedFromServer, EventArgs.Empty);
                    });

                    socketServer.On("neighborChange", (data) =>
                    {
                        _returnedFromServer = data.ToString();
                        Console.WriteLine("neighborChange");
                        neighborChange(_returnedFromServer, EventArgs.Empty);
                    });

                    socketServer.On("positionConfirmed", (data) =>
                    {
                        _returnedFromServer = data.ToString();
                        Console.WriteLine("positionConfirmed");
                        positionConfirmed(_returnedFromServer, EventArgs.Empty);
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
            //Datos en forma de Json
            String data = "{\"pcs\":[{\"nom\":\"Chikorita\",\"IP\":\"192.168.3.45\"},{\"nom\":\"Ruben\",\"IP\":\"192.168.3.58\"}],\"cliente\":{\"nom\":\"Abraham\",\"IP\":\"192.168.3.1\"},\"pos\":2,\"wall\":0}";
            socketServer.Emit("selectPosition", data);
        }
    }

}