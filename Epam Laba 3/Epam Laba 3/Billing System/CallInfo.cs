using Epam_Laba_3.ATS;
using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.Billing_System
{
    public class CallInfo:ICallInfo
    {
        public TimeSpan Duration { get; set; }
        public DateTime TimeOfCalling { get; set; }
        public PhoneNumber Caller { get; set; }
        public PhoneNumber Target { get; set; }     
        public ITariff Tariff { get; set; } 
        public double Cost { get; set; }
        public int FreeMinutes { get; set; }
    }
}
