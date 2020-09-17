using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Network
{
    /// <summary>
    /// CommandServer interface.
    /// Give access only to the Connect(), Disconnect() and SendCommand() methods.
    /// </summary>
    interface ICommandServer
    {

        void Connect();
        void Disconnect();

        void SendCommand(string command);
    }
}
