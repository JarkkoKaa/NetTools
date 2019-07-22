using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace NetTools
{
    /// <summary>
    /// Network interfaces and return IP addresses used
    /// </summary>
    class GetHostInterfaces
    {
        /// <summary>
        /// Return all network interfaces and IPv4 & IPv6 addresses
        /// </summary>
        /// <returns>IPAddress</returns>
        public void GetAll()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine($"\n{ni.Name}\tType: {ni.NetworkInterfaceType}\nDescription:{ni.Description}\n");
                if (ni.OperationalStatus != OperationalStatus.Down)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Console.WriteLine($"IPv4 address: {ip.Address}");
                            Console.WriteLine($"Subnet Mask: {ip.IPv4Mask}");
                        }

                        if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                            Console.WriteLine($"IPv6 address: {ip.Address}");
                    }
                    foreach (GatewayIPAddressInformation gw in ni.GetIPProperties().GatewayAddresses)
                    {
                        Console.WriteLine($"Default gateway: {gw.Address}");
                    }
                }
                else
                {
                    Console.WriteLine("Network interface is down");
                }
                Console.WriteLine("\n--------------------");
            }
            /* this returns IP from DHCP which is connected to internet
            // connectinf UDP socket to read local endpoint
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 11111);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
            */
        }
    }
}
