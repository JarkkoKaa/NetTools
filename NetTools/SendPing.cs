using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace NetTools
{
    class SendPing
    {
        /// <summary>
        /// Send ICMP echo request message to remote computer
        /// </summary>
        /// <param name="address"></param>
        public SendPing(IPAddress address)
        {
            // synchronous ping
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions
            {
                DontFragment = true
            };

            // buffer or 32 bytes data to be transmitted
            string data = "11111111111111111111111111111111";

            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1200;
            PingReply reply = pingSender.Send(address, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("\n+++++++++++++++\n" +
                    $"\nStatus: {reply.Status}\n" +
                    $"Address: {reply.Address.ToString()}\n" +
                    $"time: {reply.RoundtripTime}ms\n" +
                    $"Time to live: {reply.Options.Ttl}\n" +
                    $"Don't fragment: {reply.Options.DontFragment}\n" +
                    $"Bytes: {reply.Buffer.Length}\n" +
                    $"+++++++++++++++\n\n");
            }
        }
    }
}
