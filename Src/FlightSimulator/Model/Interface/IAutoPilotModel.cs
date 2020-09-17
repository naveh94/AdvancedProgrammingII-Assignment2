using FlightSimulator.Model.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    /// <summary>
    /// Auto Pilot Model Interface.
    /// Keeping the textbox content and the infoserver as properties.
    /// Got the Start() and Stop() methods in order to control the thread that read the textBox.
    /// Got the SendToServer() method in order to let the ViewModel the control on when to send the TextBox's content.
    /// </summary>
    interface IAutoPilotModel
    {
        ICommandServer Server { get; set; }
        String AutoPilotText { get; set; }

        void SendToServer();
        void Start();
        void Stop();
    }
}
