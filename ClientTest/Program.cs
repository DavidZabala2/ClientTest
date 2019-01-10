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
       
        public static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelKeyPress);
            while (true)
            {
                try
                {
                    string address = "127.0.0.1";
                    int port = 8001;

                    //Anslut till servern;
                    Console.WriteLine("Ansluter...");
                    TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect(address, port);
                    Console.WriteLine("Ansluten!");


                    //Skriv in meddelande att skicka:
                    Console.Write("Skriv in meddelande: ");
                    String message = Console.ReadLine();

                    Byte[] bMessage = System.Text.Encoding.ASCII.GetBytes(message);

                    //Skicka iväg meddelandet:
                    Console.WriteLine("Skickar...");
                    NetworkStream tcpStream = tcpClient.GetStream();
                    tcpStream.Write(bMessage, 0, bMessage.Length);

                    //Tag emote meddelande från servern:
                    Byte[] bRead = new byte[256];
                    int bReadSize = tcpStream.Read(bRead, 0, bRead.Length);

                    //Konvertera meddelandet  till ett string-objekt och skriv ut
                    string read = "";
                    for (int i = 0; i < bReadSize; i++)
                        read += Convert.ToChar(bRead[i]);

                    Console.WriteLine("Servern säger: " + read);

                    //Stäng avslutningen
                    tcpClient.Close();
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
            static void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
            {
            //CTRL + C stänger Klient
                Console.WriteLine("Klient stängdes av!");
            }
        }
    }
