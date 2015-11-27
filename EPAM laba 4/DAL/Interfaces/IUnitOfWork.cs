using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
        IRepository<Seller> Sellers { get; }
        void Save();
    }
}
