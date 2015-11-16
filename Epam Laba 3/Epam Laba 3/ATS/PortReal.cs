using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS
{
    public class PortReal:Port
    {
        public void OnOutgoingCall(object sender, Requests.Request request)
        {
            if (request.GetType() == typeof(Requests.OutgoingRequest) && this.State == PortState.connected)
            {
                this.State = PortState.calling;
            }
            
        }

        public override void RegisterEventHandlersForTerminal(ITerminal terminal)
        {
            terminal.OutgoingConnection += this.OnOutgoingCall;
            terminal.Pluging += (port, args) => { this.State = PortState.connected; };
            terminal.Unpluging += (port, args) => { this.State = PortState.disabled; };
            
        }

        public PortReal()
        {
            this.StateChanged += (sender, state) => { Console.WriteLine("Port detected the State is changed to {0}", state); };
        }
    }
}
