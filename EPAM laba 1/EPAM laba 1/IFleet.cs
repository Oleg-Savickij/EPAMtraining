using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_1
{
    public interface IFleet: IEnumerable<IPlane>
    {
        int Count { get; }
        List<IPlane> GetAll();
        void Add(IPlane item);
        bool Remove(IPlane item);
        
    }
}
