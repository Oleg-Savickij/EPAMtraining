using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS.Interfaces
{
    public interface ITariff
    {
        string Name { get; }
        int PriceOfMinute { get; }
        int FreeMinutes { get; }
        DateTime DateOfSet { get; }
    }
}
