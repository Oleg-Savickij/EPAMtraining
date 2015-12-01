using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Unit_Of_Work
{
    public interface IUnitOfWork:IDisposable
    {
        void Save();
        IRepository<ManagerDTO> Managers { get; }
        IRepository<OrderDTO> Orders { get; }
        IRepository<ClientDTO> Clients { get; }
        IRepository<ProductDTO> Products { get; }
    }
}
