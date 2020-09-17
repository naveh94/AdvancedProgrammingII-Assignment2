using FlightSimulator.Model.Interface;
using FlightSimulator.Model.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    /// <summary>
    /// Manual Control Model Class.
    /// When his properties are changed, if the Server is on will send them immidently to the server.
    /// </summary>
    class ManualControlModel : IManualControlModel
    {
        #region readonly
        private readonly String BREAK = "\r\n";
        private readonly String SET_AILERON = "set controls/flight/aileron ";
        private readonly String SET_ELEVATOR = "set controls/flight/elevator ";
        private readonly String SET_RUDDER = "set controls/flight/rudder ";
        private readonly String SET_THROTTLE = "set controls/engines/current-engine/throttle ";
        #endregion

        private double aileron;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                aileron = (value / 180) - 1;
                if (Server != null)
                {
                    SendToServer("aileron");
                }
            }
        }

        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                elevator = (value / 50) - 1;
                if (Server != null)
                {
                    SendToServer("elevator");
                }
            }
        }

        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                if (Server != null)
                {
                    SendToServer("throttle");
                }
            }
        }

        private double rudder;
        public double Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                if (Server != null)
                {
                    SendToServer("rudder");
                }
            }
        }

        public ICommandServer Server { get; set; }

        public ManualControlModel()
        {
            Server = null;
            aileron = elevator = throttle = rudder = 0;
        }

        public void SendToServer(String attribute)
        {
            switch (attribute)
            {
                case "aileron":
                    Server.SendCommand(SET_AILERON + Aileron + BREAK);
                    break;
                case "elevator":
                    Server.SendCommand(SET_ELEVATOR + Elevator + BREAK);
                    break;
                case "throttle":
                    Server.SendCommand(SET_THROTTLE + Throttle + BREAK);
                    break;
                case "rudder":
                    Server.SendCommand(SET_RUDDER + Rudder + BREAK);
                    break;
            }
        }
    }
}
