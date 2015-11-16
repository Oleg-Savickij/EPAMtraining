using Epam_Laba_3.ATS;
using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.Billing_System
{
    public interface ICallInfo
    {
        TimeSpan Duration { get; }
        DateTime TimeOfCalling { get; }
        PhoneNumber Caller { get;}
        PhoneNumber Target { get; }
        ITariff Tariff { get; }
        double Cost { get; }
        int FreeMinutes { get; }
    }
}
