using FlightSimulator.Model.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    /// <summary>
    /// ManualControl Model Interface.
    /// Keep the server as a property inorder to let the viewmodel the ability to change it incase settings were changed.
    /// Keep all the manual control stats as properties.
    /// SendToServer() methods for giving the ViewModel the control over when to send the stats to the server.
    /// </summary>
    interface IManualControlModel
    {
        ICommandServer Server { get; set; }
        double Aileron { get; set; }
        double Elevator { get; set; }
        double Throttle { get; set; }
        double Rudder { get; set; }

        void SendToServer(String attribute);
    }
}
