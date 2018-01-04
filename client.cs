//https://docs.microsoft.com/en-us/dotnet/framework/network-programming/synchronous-client-socket-example

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ZYNET
{
    public class Client
    {
        public static void Main()
        {
            IPAddress serverAddr = IPAddress.Parse("127.0.0.1");

            IPEndPoint remoteEP = new IPEndPoint(serverAddr, 8001);

            //Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //This will cause the error "No connection could be made because the target machine actively refused it".

            Socket client = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(remoteEP);

            Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

            string content = "hello world";

            byte[] bytes = Encoding.ASCII.GetBytes(content);

            client.Send(bytes);

            Console.Read();
        }
    }
}