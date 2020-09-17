using FlightSimulator.Model.Interface;
using FlightSimulator.Model.Network;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    /// <summary>
    /// AutoPilot Model Class.
    /// Contains a background thread that when started send a command from his commands BlockingCollection
    /// to the CommandServer, and wait 2 seconds. Didn't find an easy way to implement the 2 seconds waiting
    /// into the CommandServer itself without breaking the ManualControl, so added a thread to the AutoPilot instead.
    /// </summary>
    class AutoPilotModel : IAutoPilotModel
    {
        #region readonly
        private readonly String BREAK = "\r\n";
        #endregion

        private String autoPilotText;
        public String AutoPilotText
        {
            get { return autoPilotText; }
            set
            {
                autoPilotText = value;
            }
        }
        public ICommandServer Server { get; set; }
        private Thread sendingCommandsThread;
        private BlockingCollection<String> commandsCollection;

        public AutoPilotModel()
        {
            Server = null;
            commandsCollection = new BlockingCollection<string>();
        }

        public void SendToServer()
        {
            foreach (String s in autoPilotText.Split(BREAK.ToCharArray()))
            {
                commandsCollection.Add(s + BREAK);
            }
        }

        public void Start()
        {
            sendingCommandsThread = new Thread(() =>
            {
                while (true)
                {
                    if (Server != null)
                    {
                        String s = commandsCollection.Take();
                        Server.SendCommand(s);
                        Thread.Sleep(2000);
                    }
                }
            });
            sendingCommandsThread.Start();
        }

        public void Stop()
        {
            sendingCommandsThread.Abort();
        }
    }
}
