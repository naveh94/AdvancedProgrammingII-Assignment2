using FlightSimulator.Model.Interface;
using FlightSimulator.Model.Network;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    /// <summary>
    /// Flight Board model.
    /// When started, will start the Information Server and will start recieving information from it.
    /// Using a background thread.
    /// </summary>
    class FlightBoardModel : IFlightBoardModel
    {
        public IInfoServer Server { get; set; }
        private Thread infoThread;
        private FlightBoardViewModel VM_FlightBoard;

        public FlightBoardModel(FlightBoardViewModel vm)
        {
            VM_FlightBoard = vm;
            Server = null;
        }

        public void StartRecievingInfo()
        {
            infoThread = new Thread(() =>
            {
                if (Server != null)
                {
                    Server.Start();
                    while (true)
                    {
                        String buffer = Server.RecieveInfo();
                        String[] s = buffer.Split(',');
                        if (double.TryParse(s[0], out double lon))
                        {
                            VM_FlightBoard.Lon = lon;
                        }
                        if (s.Length > 1 && double.TryParse(s[1], out double lat))
                        {
                            VM_FlightBoard.Lat = lat;
                        }
                    }
                }
            });
            infoThread.Start();
        }

        public void StopRevievingInfo()
        {
            if (Server != null)
            {
                Server.Stop();
                infoThread.Abort();
            }
        }
    }
}
