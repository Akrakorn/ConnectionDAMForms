using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDam
{
    public class ClPort
    {
        /// <summary>
        /// Ports contains listening port and talking port.
        /// </summary>
        public struct Ports
        {
            public int Listener;
            public int Talker;
        }

        private static int initialPort = 5000;

        /// <summary>
        /// Function to generate port from the ip.
        /// </summary>
        /// <param name="ports">ref Ports object.</param>
        /// <param name="ipOrigin">Your Ip.("xxx.xxx.xxx.xxx")</param>
        /// <param name="ipDestiny">Neighbor ip.("xxx.xxx.xxx.xxx")</param>
        /// <returns>If there is no error returns true.</returns>
        public static Boolean GeneratePorts( ref Ports ports, String ipOrigin, String ipDestiny)
        {
            Boolean done = false;
            if (ipOrigin != "" && ipDestiny != "")
            {
                ports.Listener = initialPort + ipOrigin.Trim('.')[3];
                ports.Talker = initialPort + ipDestiny.Trim('.')[3];
                done = true;
            }
            else
            {
                ClErrors.reportError("Incorrect IP value.");
            }
            return done;
        }
    }
}
