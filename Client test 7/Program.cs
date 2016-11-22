using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Client_test_7
{
    class Program
    {
        private static string result="";
        static byte[] bytes = new byte[1024];
        static void Main(string[] args)
        {
            connect();
            listen();
          
        }
        static void listen()
        {
            bool done = false;

            TcpListener listener = new TcpListener(7000);

            listener.Start();

            while (!done)
            {
                Console.Write(result.TrimEnd());
                Console.WriteLine(result.Length);
                Console.Write("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Connection accepted.");
                NetworkStream ns = client.GetStream();

                byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
                bytes = new byte[1024];
                try
                {
                    ns.Read(bytes, 0, bytes.Length);
                    result = System.Text.Encoding.UTF8.GetString(bytes);
                    ns.Close();
                    client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            listener.Stop();

 
        }
        static void connect()
        {
             const int portNum = 6000;
            const string hostName = "127.0.0.1";

            {
                try
                {
                    TcpClient client = new TcpClient(hostName, portNum);

                    NetworkStream ns = client.GetStream();
                    BinaryWriter br = new BinaryWriter(ns);
                    Byte[] tempStr = Encoding.ASCII.GetBytes("JOIN#");
                    br.Write(tempStr);
                   

                    //Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRead));

                    client.Close();

                }
                catch (Exception e)
                {
                   
                    Console.WriteLine(e.ToString());
                }

                
            }
    }
       
    }
    }

