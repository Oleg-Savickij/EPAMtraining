using EPAM_laba_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fleet fleet = new Fleet();
            
            fleet.Add(new MilitaryPlaneItem()
            {
                Seating = 150,
                Model = "TY150",
                Producer = Company.Туполев,
                FuelConsumption = 50,
                Distance = 7000
            });

            fleet.Add(new UsualPlaneItem()
            {
                Seating = 230,
                Model = "750",
                Producer = Company.Boeing,
                FuelConsumption = 200,
                Distance = 10000
            });

            fleet.Add(new MilitaryPlaneItem()
            {
                Seating = 15,
                Model = "2",
                Producer = Company.Ильюшин,
                FuelConsumption = 25,
                Distance = 4000
            });

            
            fleet.SortBySeating();
            
            Console.WriteLine(fleet.GeneralSeating);
            IEnumerable<IPlane> a = fleet.GetByFuelConsumption(20, 100);
            foreach (IPlane item in a)
            {
                Console.WriteLine("{0} {1} {2}", item.Producer, item.Model, item.FuelConsumption);
            }

        }
    }
}
