using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.Billing_System
{
    public class Tariff:ITariff
    {
        public string Name { get; set; }
        public int PriceOfMinute { get; set; }
        public int FreeMinutes { get; set; }
        public DateTime DateOfSet { get; set; }
    }
}
