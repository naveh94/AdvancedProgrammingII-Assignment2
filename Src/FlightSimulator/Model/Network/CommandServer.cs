using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Network
{
    /// <summary>
    /// Command Server class.
    /// Contains a background thread that when started, will keep trying to take strings from the commands BlockingQueue
    /// and send them to the server it is logged to.
    /// The method SendCommand(string) adds given string to the BlockingQueue. 
    /// </summary>
    class CommandServer : ICommandServer
    {
        private IPEndPoint endPoint;
        private TcpClient client;
        private Thread clientThread;
        private BlockingCollection<String> commands;

        public CommandServer(string ip, int port)
        {
            commands = new BlockingCollection<String>();
            endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            Console.WriteLine(ip + ", " + port);
            client = new TcpClient();
            clientThread = new Thread(() =>
            {
                while (!client.Connected)
                {
                    try
                    {
                        client.Connect(endPoint);
                    }
                    catch (Exception) { }
                }
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    while (true)
                    {
                        writer.Write(Encoding.ASCII.GetBytes(commands.Take()));
                        writer.Flush();
                        Console.WriteLine("Sent command!");
                    }
                }
                
            });
        }

        public void Connect()
        {
            clientThread.Start();
        }

        public void Disconnect()
        {
            clientThread.Abort();
            client.Close();
        }

        public void SendCommand(String command)
        {
            commands.Add(command);
        }

    }
}
