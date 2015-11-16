using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Laba_3.Requests;
using Epam_Laba_3.Respond;
using Epam_Laba_3.Billing_System;

namespace Epam_Laba_3.ATS
{

    public abstract class Terminal : ITerminal
    {
        private Request ServerIncomingRequest;
        public bool IsPluged { get; set; }
        public PhoneNumber Number { get; set; }
        
        protected bool IsOnline { get; private set; }
        public Terminal(PhoneNumber number)
        {
            this.Number = number;
            
        }

        public event EventHandler<Request> OutgoingConnection;
        protected virtual void OnOutgoingCall(object sender,PhoneNumber target)
        {
            if(OutgoingConnection!=null)
            {
                ServerIncomingRequest = new Requests.OutgoingRequest() { Source = this.Number, Target = target };
                OutgoingConnection(sender, ServerIncomingRequest);
            }
        }

        public event EventHandler<IncommingRequest> IncommingCallRequest;
        protected virtual void OnIncomingRequest(object sender, IncommingRequest request)
        {
            if (IncommingCallRequest!=null)
            {
                IncommingCallRequest(sender, request);
            }
            ServerIncomingRequest = request;
        }

        public void IncomingRequestFrom(PhoneNumber source)
        {
            OnIncomingRequest(this, new IncommingRequest() { Source = source });
        }

        

        public void Drop()
        {
            if (ServerIncomingRequest != null)
            {
                if (IsOnline)
                {
                    OnOffline(this, null);
                }
                OnIncomingRespond(this, new Respond.Respond() { Source = Number, State = Respond.RespondState.Drop, Request = ServerIncomingRequest });
                ServerIncomingRequest = null;
            }
        }

        public void Answer()
        {
            if (!IsOnline && ServerIncomingRequest != null)
            {
                OnOnline(this, null);
                OnIncomingRespond(this, new Respond.Respond() { Source = Number, State = Respond.RespondState.Accept, Request = ServerIncomingRequest });            
            }
            else { OnOffline(this, null); }
        }

        public event EventHandler<Respond.Respond> IncomingRespond;

        protected virtual void OnIncomingRespond(object sender,Respond.Respond respond)
        {
            if (IncomingRespond != null && ServerIncomingRequest != null)
            {
                IncomingRespond(sender, respond);
            }
        }

        public event EventHandler Online;
        public event EventHandler Offline;

        protected virtual void OnOnline(object sender,EventArgs args)
        {
            if(Online!=null)
            {
                Online(sender, args);
            }
            IsOnline = true;
        }

        protected virtual void OnOffline(object sender,EventArgs args)
        {
            if(Offline!=null)
            {
                Offline(sender, args);
            }
            IsOnline = false;
        }


        public event EventHandler Pluging;
        public event EventHandler Unpluging;

        public void Plug()
        {
            OnPlugging(this, null);
        }

        public void UnPlug()
        {
            if (IsOnline)
            {
                Drop();       
            }
            OnUnPlugging(this, null);
        }

        protected virtual void OnPlugging(object sender,EventArgs args)
        {
            if(Pluging!=null)
            {
                Pluging(sender, args);
            }
            IsPluged = true;
        }

        protected virtual void OnUnPlugging(object sender,EventArgs args)
        {
            if(Unpluging!=null)
            {
                Unpluging(sender, args);
            }
            IsPluged = false;
        }

        public void ClearEvents()
        {
            this.IncommingCallRequest = null;
            this.IncomingRespond = null;
            this.Online = null;
            this.Offline = null;
            this.OutgoingConnection = null;
            this.Pluging = null;
            this.Unpluging = null;
        }

        public void Call(PhoneNumber target)
        {
            if (!IsOnline && IsPluged)
            { 
                OnOnline(this, null);
                OnOutgoingCall(this, target);
                
            }
        }

        public virtual void RegisterEventHandlersForPort(IPort port)
        {
            port.StateChanged += (sender, state) =>
            {
                if (IsOnline && state == PortState.connected)
                {
                    this.OnOffline(sender, null);
                }
            };
        }
        
       
    }
}
