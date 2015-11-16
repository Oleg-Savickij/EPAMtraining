using EPAM_laba_1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_1
{
    public class Fleet: IFleet
    {
        private List<IPlane> _fleet = new List<IPlane>();

        public int Count
        {
            get
            {
                return _fleet.Count;
            }
        }

        public List<IPlane> GetAll()           
        {
            return _fleet;
        }

        public void Add(IPlane item)
        {
            _fleet.Add(item);
        }

        public void Clear()
        {
            _fleet.Clear();
        }

        public bool Contains(IPlane item)
        {
            return _fleet.Contains(item);
        }

        public void CopyTo(IPlane[] array, int arrayIndex)
        {
            _fleet.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IPlane> GetEnumerator()
        {
            return _fleet.GetEnumerator();
        }

        public bool Remove(IPlane item)
        {
            return _fleet.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _fleet.GetEnumerator();
        }

        public void SortBySeating()
        {
             _fleet.Sort(delegate(IPlane item1, IPlane item2) 
                               {
                                   return item1.Distance.CompareTo(item2.Distance);
                               });
        }

        public int GeneralCapacity
        {
            get
            {
                int sum = 0;
                foreach (var item in _fleet)
                {
                    sum += item.Capacity;
                }
                return sum;
            }
        }

        public int GeneralSeating
        {
            get
            {
                int sum = 0;
                foreach (var item in _fleet)
                {
                    sum += item.Seating;
                }
                return sum;
            }
        }

        public IEnumerable<IPlane> GetByFuelConsumption(int x1,int x2)                     
        {
            IEnumerable<IPlane> results = _fleet.Where(a => ((a.FuelConsumption > x1) && (a.FuelConsumption < x2)));
            return results;
        }


    }
}
