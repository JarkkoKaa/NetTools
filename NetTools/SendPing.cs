using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace NetTools
{
    class SendPing
    {
        /// <summary>
        /// Send ICMP echo request message to remote computer
        /// </summary>
        /// <param name="address"></param>
        public SendPing(string hostOrAddress)
        {
            // synchronous ping
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions
            {
                DontFragment = true
            };

            // buffer of 32 bytes data to be transmitted
            string data = "11111111111111111111111111111111";

            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1200;

            int count = 0;
            Console.WriteLine("\n+++++++++++++++\n");
            while (count <= 2)
            {
                try { 
                    PingReply reply = pingSender.Send(hostOrAddress, timeout, buffer, options);
                
                    Console.WriteLine($"Address: {reply.Address.ToString()}\n" +
                    $"Status: {reply.Status}\n" +
                    $"time: {reply.RoundtripTime}ms\n" +
                    $"Time to live: {reply.Options.Ttl}\n\n");
                    if (count == 2)
                    {
                        Console.WriteLine("+++++++++++++++\n" +
                        $"Don't fragment: {reply.Options.DontFragment}\n" +
                        $"Bytes: {reply.Buffer.Length}\n\n");
                    }
                    count++;
                } catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    Console.WriteLine("Invalid address: "+hostOrAddress);
                    break;
                }
            }

            if (pingSender != null)
            {
                pingSender.Dispose();
            }
        }
    }
}
