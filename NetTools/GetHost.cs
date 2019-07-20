using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetTools
{
    class GetHost
    {
        /// <summary>
        /// Get host computers IP address
        /// </summary>
        /// <returns>IPAddress</returns>
        public string GetHostIP()
        {
            // connectinf UDP socket to read local endpoint
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 11111);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }
    }
}
