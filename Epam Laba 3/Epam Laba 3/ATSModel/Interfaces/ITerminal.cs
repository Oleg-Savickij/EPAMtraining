using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS.Interfaces
{
    public interface ITerminal:IClearAllEvents
    {
        PhoneNumber Number { get; }
        bool IsPluged { get; }
        event EventHandler<Requests.Request> OutgoingConnection;
        event EventHandler<Requests.IncommingRequest> IncommingCallRequest;
        event EventHandler<Respond.Respond> IncomingRespond;
        event EventHandler Online;
        event EventHandler Offline;
        event EventHandler Pluging;
        event EventHandler Unpluging;


        void Call(PhoneNumber target);
        void IncomingRequestFrom(PhoneNumber sourse);
        void Drop();
        void Answer();
        void RegisterEventHandlersForPort(IPort port);
        void Plug();
        void UnPlug();


    }
}
