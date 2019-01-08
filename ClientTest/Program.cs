using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "127.0.0.1";
            int port = 8001;

            Console.WriteLine("Anluster...");
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(address, port);
            Console.WriteLine("Ansluten!");

            Console.Write("Skriv in meddelande: ");
            string message = Console.ReadLine();

            Byte[] bMessage = System.Text.Encoding.UTF8.GetBytes(message);

            Console.WriteLine("Skickar...");
            NetworkStream tcpStream = tcpClient.GetStream();
            tcpStream.Write(bMessage, 0, bMessage.Length);

            tcpClient.Close();





        }
    }
}
