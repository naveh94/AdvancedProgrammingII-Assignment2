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
    /// Information Server Interface.
    /// Give access only to the Start(), Stop() and RecieveInfo() methods.
    /// </summary>
    interface IInfoServer
    {
        void Start();
        void Stop();

        String RecieveInfo();

    }
}
