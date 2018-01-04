//https://docs.microsoft.com/en-us/dotnet/framework/network-programming/synchronous-server-socket-example

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ZYNET
{
    public class Server
    {
        public const int backlog = 10;

        public static void Main()
        {
            IPAddress serverAddr = IPAddress.Parse("127.0.0.1");

            IPEndPoint listenEP = new IPEndPoint(serverAddr, 8001);

            Socket server = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //If we comment out the line below,we will get a "Unhandled Exception: System.Net.Sockets.SocketException: An invalid argument was supplied
            //at System.Net.Sockets.Socket.Listen(Int32 backlog)" error.
            server.Bind(listenEP);

            server.Listen(backlog);

            Socket client = server.Accept();

            Console.WriteLine("Accept socket {0}",
                    client.RemoteEndPoint.ToString());

            string content = "hello world";

            byte[] bytes = Encoding.ASCII.GetBytes(content);

            byte[] bytesRecv = new byte[1024];

            client.Receive(bytesRecv);

            string recv = Encoding.ASCII.GetString(bytesRecv);

            Console.WriteLine(recv);

            Console.Read();
        }
    }
}