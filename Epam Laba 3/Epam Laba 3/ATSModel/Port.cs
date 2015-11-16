using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS
{
    public abstract class Port:IPort
    {
        private PortState _state = PortState.disabled;
        public PortState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    OnStateChanging(this, value);
                    _state = value;
                    OnStateChanged(this, _state);
                }
            }
        }

        public void OnStateChanged(object sender, PortState state)
        {
            if (StateChanged != null)
            {
                StateChanged(sender, state);
            }
        }

        public void OnStateChanging(object sender, PortState newState)
        {
            if (StateChanging != null)
            {
                StateChanging(sender, newState);
            }
        }

        public event EventHandler<PortState> StateChanged;
        public event EventHandler<PortState> StateChanging;

        public abstract void RegisterEventHandlersForTerminal(ITerminal terminal);
        public void ClearEvents()
        {
            this.StateChanged = null;
            this.StateChanging = null;
        }

       

    }
}
