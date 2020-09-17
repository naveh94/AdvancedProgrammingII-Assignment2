using FlightSimulator.Model.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    /// <summary>
    /// FlightBoardModel interface.
    /// Keeping the server as a property in order to let the ViewModel the ability to change it in case
    /// the settings were changed.
    /// StartRecievingInfo() and StopRecievingInfo() in order to control when it get info from the server and when it stops.
    /// </summary>
    interface IFlightBoardModel
    {
        IInfoServer Server { get; set; } 
        void StartRecievingInfo();
        void StopRevievingInfo();
    }
}
