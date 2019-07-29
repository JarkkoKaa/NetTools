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
                    $"Local host name: {Dns.GetHostName()}\n");

            while (choice != 99)
            {
                isByte = true;
                
                Console.WriteLine("1) Ping\n" +
                    "2) Network interfaces\n" +
                    "99) Quit");
                isByte = byte.TryParse(Console.ReadLine(), out choice);

                if (!isByte)
                    continue;

                switch (choice)
                {
                    case 1:
                        Console.Write("Hostname or IP address: ");
                        string hostOrAddress = Console.ReadLine();
                        SendPing sp = new SendPing(hostOrAddress);
                        break;
                    case 2:
                        GetHostInterfaces ghi = new GetHostInterfaces();
                        ghi.GetAll();
                        break;
                }
            }
        }
    }
}
