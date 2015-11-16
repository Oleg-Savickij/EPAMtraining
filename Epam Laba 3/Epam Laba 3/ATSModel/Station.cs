using Epam_Laba_3.ATS.Interfaces;
using Epam_Laba_3.Billing_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS
{    
    public abstract class Station:IStation
    {
        private ICollection<CallInfo> _connectionCollection = new List<CallInfo>();
        private ICollection<CallInfo> _callCollection = new List<CallInfo>();
        private ICollection<ITerminal> _terminals = new List<ITerminal>();
        private ICollection<IPort> _ports = new List<IPort>();
        private IDictionary<PhoneNumber, ITariff> _tariffMaping = new Dictionary<PhoneNumber, ITariff>();
        private IDictionary<PhoneNumber, IPort> _portMapping = new Dictionary<PhoneNumber, IPort>();

        public Station(ICollection<IPort> ports)
        {
            _ports = ports;
        }

        protected ITerminal GetTerminalByPhoneNumber(PhoneNumber number)
        {
            return _terminals.FirstOrDefault(x => x.Number.Equals(number));
        }

        protected IPort GetPortByPhoneNumber(PhoneNumber number)
        {
            try
            {
                return _portMapping[number];
            }
            catch (KeyNotFoundException)
            {               
                return new PortReal();
            }
        }

        protected ITariff GetTariffByPhoneNumber(PhoneNumber number)
        {
            try
            {
                return _tariffMaping[number];
            }
            catch (KeyNotFoundException)
            {
                this.SetTariffForTerminal(number, TariffList.SetCommonTariff());
                return _tariffMaping[number];
            }
            
        }



        public abstract void RegisterEventHandlersForTerminal(ITerminal terminal);
        public abstract void RegisterEventHandlersForPort(IPort port, ITerminal terminal);

        public void Add(ITerminal terminal)
        {
            var freePort = _ports.Except(_portMapping.Values).FirstOrDefault();
            if (freePort != null)
            {
                _terminals.Add(terminal);

                MapTerminalToPort(terminal, freePort);

                this.RegisterEventHandlersForTerminal(terminal);
                this.RegisterEventHandlersForPort(freePort,terminal);
            }
        }
        protected void MapTerminalToPort(ITerminal terminal, IPort port)
        {
            _portMapping.Add(terminal.Number, port);
            port.RegisterEventHandlersForTerminal(terminal);
            terminal.RegisterEventHandlersForPort(port);
        }

        protected void UnMapTerminalFromPort(ITerminal terminal, IPort port)
        {
            _portMapping.Remove(terminal.Number);
            terminal.ClearEvents();
            port.ClearEvents();
        }
        public event EventHandler<PhoneNumber> TerminalChangedTariff;

        protected virtual void OnTerminalChangedTariff(object sender,PhoneNumber number)
        {
            if (TerminalChangedTariff!=null)
            {
                TerminalChangedTariff(sender, number);
            }
        }
        public bool SetTariffForTerminal(PhoneNumber number, ITariff tariff)
        {
            bool isChanged = false;
            if (!_tariffMaping.Keys.Contains(number)) { _tariffMaping.Add(number, tariff); isChanged = true; }
            else
            {                
                if ((DateTime.Now -_tariffMaping[number].DateOfSet).Days >= DateTime.DaysInMonth(_tariffMaping[number].DateOfSet.Year, (_tariffMaping[number].DateOfSet).Month))
                {
                    _tariffMaping[number] = tariff;
                    isChanged = true;
                }
                else { isChanged = false; }
            }
            if (isChanged) { OnTerminalChangedTariff(this, number); }
            return isChanged;
            
        }

        protected void RegisterOutgoingRequest(Requests.OutgoingRequest request)
        {
            if ((request.Source != default(PhoneNumber) && request.Target != default(PhoneNumber)) &&
                (GetCallInfo(request.Source) == null && GetConnectionInfo(request.Source) == null))
            {
                var callInfo = new CallInfo()
                {
                    Tariff = GetTariffByPhoneNumber(request.Source),
                    Caller = request.Source,
                    Target = request.Target,
                    TimeOfCalling = DateTime.Now
                };

                ITerminal targetTerminal = GetTerminalByPhoneNumber(request.Target);
                IPort targetPort = GetPortByPhoneNumber(request.Target);
                IPort sourcePort = GetPortByPhoneNumber(request.Source);
                

                if (targetPort.State == PortState.connected)
                {
                    _connectionCollection.Add(callInfo);
                    targetPort.State = PortState.calling;
                    targetTerminal.IncomingRequestFrom(request.Source);
                }
                else
                {
                    sourcePort.State = PortState.connected;
                    OnCallInfoPrepared(this, callInfo);                    
                }
            }
        }

        

        public event EventHandler<CallInfo> CallInfoPrepared;

        protected virtual void OnCallInfoPrepared(object sender, CallInfo callInfo)
        {           
            if (CallInfoPrepared != null)
            {
                CallInfoPrepared(sender, callInfo);
            }
        }

        protected CallInfo GetConnectionInfo(PhoneNumber actor)
        {
            return this._connectionCollection.FirstOrDefault(x => (x.Caller.Value == actor.Value || x.Target.Value == actor.Value));
        }

        protected CallInfo GetCallInfo(PhoneNumber actor)
        {
            return this._callCollection.FirstOrDefault(x => (x.Caller.Value == actor.Value || x.Target.Value == actor.Value));
        }

        protected void SetPortStateWhenConnectionInterrupted(PhoneNumber source, PhoneNumber target)
        {
            var sourcePort = GetPortByPhoneNumber(source);
            if (sourcePort != null)
            {
                sourcePort.State = PortState.connected;
            }

            var targetPort = GetPortByPhoneNumber(target);
            if (targetPort != null)
            {
                targetPort.State = PortState.connected;
            }
        }

        protected void InterruptConnection(CallInfo callInfo)
        {
            this._callCollection.Remove(callInfo);
            SetPortStateWhenConnectionInterrupted(callInfo.Caller, callInfo.Target);
            OnCallInfoPrepared(this, callInfo);
        }

        protected void InterruptActiveCall(CallInfo callInfo)
        {
            Thread.Sleep(1000);
            callInfo.Duration = DateTime.Now - callInfo.TimeOfCalling;
            this._callCollection.Remove(callInfo);
            SetPortStateWhenConnectionInterrupted(callInfo.Caller, callInfo.Target);
            OnCallInfoPrepared(this, callInfo);
        }

        public void OnIncomingCallRespond(object sender, Respond.Respond respond)
        {
            var registeredCallInfo = GetConnectionInfo(respond.Source);
            if (registeredCallInfo != null)
            {
                switch (respond.State)
                {
                    case Respond.RespondState.Drop:
                        {
                            InterruptConnection(registeredCallInfo);
                            break;
                        }
                    case Respond.RespondState.Accept:
                        {
                            MakeCallActive(registeredCallInfo);
                            break;
                        }
                }
            }
            else
            {
                CallInfo currentCallInfo = GetCallInfo(respond.Source);
                if (currentCallInfo != null)
                {
                    this.InterruptActiveCall(currentCallInfo);
                }
            }
        }

        protected void MakeCallActive(CallInfo callInfo)
        {
            this._connectionCollection.Remove(callInfo);
            callInfo.TimeOfCalling = DateTime.Now;
            this._callCollection.Add(callInfo);
        }

        public void ClearEvents()
        {
            this.CallInfoPrepared = null;
        }

        public void DisabledTerminal(PhoneNumber number)
        {
            var port = _portMapping[number];
            var terminal = this.GetTerminalByPhoneNumber(number);
            this.UnMapTerminalFromPort(terminal, port);
        }
    }
}
