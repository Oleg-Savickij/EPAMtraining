
using DAL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<ManagerDTO> Managers { get; }
        IRepository<OrderDTO> Orders { get; }
        void Save();
    }
}
