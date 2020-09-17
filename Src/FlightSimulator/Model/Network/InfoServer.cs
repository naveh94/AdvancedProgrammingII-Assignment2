using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Network
{
    /// <summary>
    /// Information Server Class.
    /// Doesn't use a thread, so when used should be put on a thread.
    /// </summary>
    class InfoServer : IInfoServer
    {
        private String serverIP;
        private int serverPort;
        private TcpListener listener;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        

        public InfoServer(String ip, int port)
        {
            serverIP = ip;
            serverPort = port;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            listener = new TcpListener(ep);
        }

        public void Start()
        {
            listener.Start();
            try
            {
                client = listener.AcceptTcpClient();
            } catch (Exception) { }
            stream = client.GetStream();
            reader = new BinaryReader(stream);
        }

        public String RecieveInfo()
        {
            String buffer = "";
            char c;
            do
            {
                c = reader.ReadChar();
                buffer += c;
            } while (c != '\n');
            return buffer;
        }


        public void Stop()
        {
            if (client != null)
            {
                reader.Close();
                stream.Close();
                client.Close();
            }
            listener.Stop();
        }
    }
}
