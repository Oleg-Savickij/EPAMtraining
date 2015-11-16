using Epam_Laba_3.ATS;
using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.Billing_System
{
    public class BillingSystem
    {
        public static void ShowCallInfo(List<ICallInfo> calls)
        {
            foreach (var item in calls)
            {
                Console.WriteLine("{0} call {1};  Date {2}; Duration {3}; Cost {4}; FreeMinutes {5}", item.Caller.Value, item.Target.Value, item.TimeOfCalling, item.Duration,item.Cost,item.FreeMinutes);
            }
        }

        private readonly ICollection<ICallInfo> _callsCollection = new List<ICallInfo>();
        private IDictionary<PhoneNumber, double> _clientScore = new Dictionary<PhoneNumber, double>();
        private IDictionary<PhoneNumber, double> _clientFreeMinutes = new Dictionary<PhoneNumber, double>();
        public void Add(object sender,CallInfo item)
        {
            try
            {
                _clientFreeMinutes[item.Caller] = item.Tariff.FreeMinutes;
            }
            catch (KeyNotFoundException)
            {
                _clientFreeMinutes.Add(item.Caller, item.Tariff.FreeMinutes);
            }

            double score = 0;
            try
            {
                score = _clientScore[item.Caller];
            }
            catch (KeyNotFoundException)
            {
                _clientScore.Add(item.Caller, 0);
            }
            
            if (item.Duration.Minutes+1 >= _clientFreeMinutes[item.Caller])
            {
                item.Cost = (item.Duration.Minutes - _clientFreeMinutes[item.Caller]+1) * item.Tariff.PriceOfMinute;
                _clientFreeMinutes[item.Caller] = 0;
                item.FreeMinutes = 0;
            }
            else {
                _clientFreeMinutes[item.Caller] -= item.Duration.Minutes + 1;
                item.FreeMinutes = (int)_clientFreeMinutes[item.Caller];
            }
            score += item.Cost;
            _clientScore[item.Caller] = score;
            _callsCollection.Add(item);
        }
        public void RegisterEventHandlerForStation(IStation station)
        {
            station.CallInfoPrepared += this.Add;
            station.TerminalChangedTariff += this.SetFreeMinutes;
        }

        public double CalculateClient(PhoneNumber number)
        {
            try
            {
                return _clientScore[number];
            }
            catch (KeyNotFoundException)
            {

                return 0;
            }
            
        }

        private void SetFreeMinutes(object sender,PhoneNumber number)
        {
            try
            {
                _clientFreeMinutes[number] = 0;
            }
            catch (KeyNotFoundException)
            {
                _clientFreeMinutes.Add(number, 0);
            }
        }

        public List<ICallInfo> GetCallInfoByNumber(PhoneNumber number)
        {
            var calls = _callsCollection
                .Where(x => x.Caller.Value == number.Value).ToList();               
            return calls;
        }

        public List<ICallInfo> GetCallInfoByPeriod(PhoneNumber number,DateTime startDate,DateTime endDate)
        {
            var calls = _callsCollection.Where(x => ((x.Caller.Value == number.Value) && (x.TimeOfCalling>startDate) && (x.TimeOfCalling<endDate))).ToList();
            return calls;
        }

        public List<ICallInfo> GetCallInfoByCost(PhoneNumber number, double cost)
        {
            var calls = _callsCollection.Where(x => ((x.Caller.Value == number.Value) && (x.Cost == cost))).ToList();
            return calls;
        }
    }
}
