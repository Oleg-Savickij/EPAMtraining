using Epam_Laba_3.ATS;
using Epam_Laba_3.ATS.Interfaces;
using Epam_Laba_3.Billing_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPort> ports = new List<IPort> { new PortReal(), new PortReal(),new PortReal() };
            StationReal n = new StationReal(ports);
            
            BillingSystem s = new BillingSystem();
            s.RegisterEventHandlerForStation(n);
            ITerminal t = new TerminalReal(new PhoneNumber("123-45-67"));
            ITerminal t1 = new TerminalReal(new PhoneNumber("765-43-21"));
            ITerminal t2 = new TerminalReal(new PhoneNumber("000-11-11"));
            n.Add(t);
            n.Add(t1);
            n.Add(t2);
            t2.Plug();
            t.Plug();
            t1.Plug();
            
            TariffList tariffs = new TariffList();
            //Add new tariff
            tariffs.Add(new Tariff { FreeMinutes = 10, Name = "Gold tariff", PriceOfMinute = 5 });
            //Change tariff for client
            if (n.SetTariffForTerminal(new PhoneNumber("123-45-67"), tariffs.GetByName("Gold tariff"))) { Console.WriteLine("123-45-67 changed tariff to Gold tariff"); }  
            t.Call(new PhoneNumber("765-43-21"));
            t1.Answer();          
            t1.Drop();

            double score = s.CalculateClient(new PhoneNumber("123-45-67"));
            Console.WriteLine(score);
            t1.Call(new PhoneNumber("123-45-67"));
            t.Answer();

            //Try call, when target is alredy talk
            t2.Call(new PhoneNumber("765-43-21"));

            t1.Drop();
            DateTime startDate = new DateTime(2010,11,15);


            var calls = s.GetCallInfoByPeriod(new PhoneNumber("765-43-21"), startDate, new DateTime(2015,11,11));
            BillingSystem.ShowCallInfo(calls);


            var calls1 = s.GetCallInfoByNumber(new PhoneNumber("765-43-21"));            
            BillingSystem.ShowCallInfo(calls1);


            score = s.CalculateClient(new PhoneNumber("765-43-21"));
            Console.WriteLine(score);


            var clientCalls = s.GetCallInfoByNumber(new PhoneNumber("123-45-67"));
            BillingSystem.ShowCallInfo(clientCalls);
        }
    }
}
