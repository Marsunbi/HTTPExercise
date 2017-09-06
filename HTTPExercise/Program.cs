using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace HTTPExercise
{
    class Program
    {
        Socket client;
        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;
        string content;

        public string Date { set { } get { return DateTime.Now.ToString("dd / mm / yyyy"); } }
        public string Time { set { } get { return DateTime.Now.ToString("hh:mm"); } }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 12000);
            listener.Start();

            while (true)
            {
                client = listener.AcceptSocket();

                stream = new NetworkStream(client);
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                string input = reader.ReadLine();
                Console.WriteLine(input);
                string[] page = input.Split(' ');
                
                switch (page[1].ToLower())
                {
                    case "/date":
                        content = Date;
                        break;
                    case "/time":
                        content = Time;
                        break;
                    default:
                        content = "Invalid command";
                        break;
                }

                writer.WriteLine("HTTP/1.1 200 OK");
                writer.WriteLine("Content-Type text/plain");
                writer.WriteLine($"Content-Lenght: {content.Length}");
                writer.WriteLine();
                writer.WriteLine(content);

                writer.Flush();
                stream.Close();
                client.Close();
            }
        }
    }
}
