using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Laba_3.Billing_System;

namespace Epam_Laba_3.ATS
{
    public class TerminalReal : Terminal
    {
        public TerminalReal(PhoneNumber number) : base(number)
        {
            this.IncommingCallRequest += this.OnIncomingRequest;
            this.Online += (sender, args) => { Console.WriteLine("Terminal {0} turned to online mode", Number.Value); };
            this.Offline += (sender, args) => { Console.WriteLine("Terminal {0} turned to offline mode", Number.Value); };
        }


        public void OnIncomingRequest(object sender, Requests.IncommingRequest request)
        {
            Console.WriteLine("{0} received request for incoming connection from {1}", this.Number.Value, request.Source.Value);
        }



    }
}
