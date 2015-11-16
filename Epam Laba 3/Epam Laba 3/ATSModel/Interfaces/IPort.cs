using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS.Interfaces
{
    public interface IPort:IClearAllEvents
    {
        PortState State { get; set; }

        event EventHandler<PortState> StateChanging;
        event EventHandler<PortState> StateChanged;

        void RegisterEventHandlersForTerminal(ITerminal terminal);
    }
}
