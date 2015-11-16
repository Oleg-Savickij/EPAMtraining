using EPAM_laba_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_1
{
    public interface IPlane
    {
        TypeOfPlane Type { get; }
        Company Producer { get; }
        string Model { get; }
        int Distance { get; }
        int FuelConsumption { get; }
        int Capacity { get; }

    }
}
