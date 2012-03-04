using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace CogitoProject.Network
{
    public static class Server
    {
        public static void initializeServer()
        {
            Thread listener = new Thread(new ThreadStart(listenForConnection));
            listener.IsBackground = true;
            listener.Start();
        }

        private static void listenForConnection()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 4862));
            socket.Listen(2);

            while (true)
            {
                using (Socket newConnection = socket.Accept())
                {
                    //byte[] msg = Encoding.UTF8.GetBytes("Hello World!");
                    //newConnection.Send(msg, SocketFlags.None);
                }
            }
        }
    }
}