using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.EventArgs
{
    /// <summary>
    /// Event Arguments used for passing joystick movement events.
    /// </summary>
    public class VirtualJoystickEventArgs
    {
        public double Aileron { get; set; }
        public double Elevator { get; set; }
    }
}
