using System;
using System.Net;

namespace NetTools
{
    class Program
    {
        static void Main(string[] args)
        {
            byte choice = 0;
            bool isByte;

            Console.WriteLine("\n+++++++++++++++\n" +
                    "NET TOOLS\n" +
                    "+++++++++++++++\n" +
                    "Author: Jarkko Kaartinen - 2019\n\n" +
                    $"Your machine: {Environment.MachineName}\n" +
                    $"Your IP: {Dns.GetHostEntry(Dns.GetHostName())}\n");

            while (choice != 99)
            {
                isByte = true;
                
                Console.WriteLine("1) Ping\n" +
                    "99) Quit");
                isByte = byte.TryParse(Console.ReadLine(), out choice);

                if (!isByte)
                    continue;

                bool isCorrect;
                switch (choice)
                {
                    case 1:
                        Console.Write("Ping IP address: ");
                        IPAddress ipAddress; 
                        isCorrect = IPAddress.TryParse(Console.ReadLine(), out ipAddress);
                        if (isCorrect)
                        {
                            SendPing sp = new SendPing(ipAddress);
                        }
                        else
                            Console.WriteLine("Invalid address");
                        break;
                }
            }
        }
    }
}
