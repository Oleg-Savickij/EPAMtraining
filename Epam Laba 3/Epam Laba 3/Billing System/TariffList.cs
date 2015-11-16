using Epam_Laba_3.ATS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.Billing_System
{
    public class TariffList
    {
        private static ICollection<ITariff> _tarifs = new List<ITariff> { (new Tariff
        {
            Name = "Common Tariff",
            FreeMinutes = 0,
            PriceOfMinute = 10
        })
        };
        public void Add(Tariff item)
        {
            if(item!=null)
            {
                _tarifs.Add(item);
            }
        }

        public void Remove(Tariff item)
        {
            if (item != null)
            {
                _tarifs.Remove(item);
            }
        }

        public static ITariff SetCommonTariff()
        {               
            return _tarifs.First();
        }

        public ITariff GetByName(string name)
        {
            var tarrif = _tarifs.Where(x => x.Name == name).ToArray();
            return tarrif[0];
        }
    }
}
