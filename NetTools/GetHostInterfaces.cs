using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Linq;

namespace NetTools
{
    /// <summary>
    /// List of network interfaces
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
                    var defaultGateway = ni.GetIPProperties().GatewayAddresses.FirstOrDefault(g => g.Address.AddressFamily.ToString() == "InterNetwork");
                    if (defaultGateway != null)
                    {
                        Console.WriteLine($"Default gateway: {defaultGateway.Address}\n");
                    }
                    if (ni.GetPhysicalAddress().GetAddressBytes().Length > 0)
                        Console.WriteLine($"Physical address: {ni.GetPhysicalAddress().ToString()}");
                }
                else
                {
                    Console.WriteLine("Network interface is down");
                }
                Console.WriteLine("\n--------------------");
            }
        }
    }
}
