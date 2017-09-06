using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Please enter servername");
            string server = Console.ReadLine();
            Console.WriteLine("");

            TcpClient client = new TcpClient();
            client.Connect("webservicedemo.datamatiker-skolen.dk", 80);
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());

            writer.WriteLine("GET /RegneWcfService.svc/RESTjson/Add?a=4&b=5 HTTP/1.1");
            writer.WriteLine("Host: webservicedemo.datamatiker-skolen.dk\n\n");
            writer.Flush();

            int r = 0;
            while (r > -1)
            {
                r = reader.Read();
                Console.Write((char)r);
            }
        }
    }
}
