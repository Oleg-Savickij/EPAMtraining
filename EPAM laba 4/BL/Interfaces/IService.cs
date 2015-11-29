using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IService
    {
        void MakeOrder(Order order);
        void AddSeller(Seller seller);
        void AddProduct(Product product);

        void Save();
        void Dispose();
    }
}
