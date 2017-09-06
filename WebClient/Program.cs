using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WebClientClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Addere tal med WebCLient
            {
                WebClient client = new WebClient();
                //client.Headers.Add("Content-Type", "text/plain; charset=UTF-8");  // ekstra header info
                //client.Encoding = Encoding.UTF8;                                  // ekstra om encoding
                string message = client.DownloadString("http://webservicedemo.datamatiker-skolen.dk/RegneWcfService.svc/RESTjson/Add?a=5&b=8");
                Console.WriteLine("Besked: " + message);
            }

            //{
            //    WebClient client = new WebClient();
            //    //client.Headers.Add("Content-Type", "text/plain; charset=UTF-8");  // ekstra header info
            //    //client.Encoding = Encoding.UTF8;                                  // ekstra om encoding
            //    string message = client.DownloadString("http://bjoerks.net/test/test.txt");
            //    Console.WriteLine("Besked:" + message + ":slut på besked");
            //}

            //{
            //    WebClient client = new WebClient();
            //    //client.Headers.Add("Content-Type", "text/htm; charset=UTF-8");     // ekstra header info
            //    //client.Encoding = Encoding.UTF8;                                   // ekstra om encoding
            //    string message = client.DownloadString("http://bjoerks.net/datamatiker/Csharp/Opgaver/OpgaverHttp.htm");
            //    Console.WriteLine("Besked:" + message + ":slut på besked");
            //}

            Console.ReadLine();
        }
    }
}
