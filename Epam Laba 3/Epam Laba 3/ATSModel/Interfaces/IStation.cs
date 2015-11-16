using Epam_Laba_3.Billing_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS.Interfaces
{
    public interface IStation
    {
        void RegisterEventHandlersForTerminal(ITerminal terminal);
        void RegisterEventHandlersForPort(IPort port, ITerminal terminal);
        event EventHandler<CallInfo> CallInfoPrepared;
        event EventHandler<PhoneNumber> TerminalChangedTariff;

    }
}
