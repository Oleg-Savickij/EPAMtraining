using EPAM_laba_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_1
{
    public abstract class Plane : IPlane
    {
        public TypeOfPlane Type { get; set; }
        public Company Producer { get; set; }
        public string Model { get; set; }       
        public int Distance { get; set; }        
        public int FuelConsumption { get; set; }
        public int Capacity { get; set; }
        public string Owner { get; set; }
        public int BodySpace { get; set; }
        public int Seating { get; set; }

    }
}
