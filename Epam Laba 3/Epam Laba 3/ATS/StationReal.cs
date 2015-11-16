using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Laba_3.ATS.Interfaces;
using Epam_Laba_3.Billing_System;

namespace Epam_Laba_3.ATS
{
    public class StationReal : Station
    {
        public StationReal(ICollection<IPort> ports):base(ports)
        {

        }
        public void OnOutgoingRequest(object sender, Requests.Request request)
        {
            if (request.GetType() == typeof(Requests.OutgoingRequest))
            {
                RegisterOutgoingRequest(request as Requests.OutgoingRequest);
            }
            
        }

        public override void RegisterEventHandlersForTerminal(ITerminal terminal)
        {
            terminal.OutgoingConnection += this.OnOutgoingRequest;
            terminal.IncomingRespond += OnIncomingCallRespond;
            
        }

        public override void RegisterEventHandlersForPort(IPort port, ITerminal terminal)
        {
            port.StateChanged += (sender, state) => { Console.WriteLine("Station detected the port {1} changed its State to {0}", state,terminal.Number.Value); };
        }

       

    }
}
