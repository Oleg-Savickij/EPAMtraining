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
        void MakeOrder(Order orderDto);
        Order GetOrder(int? id);
        IEnumerable<Order> GetOrders();
        void Dispose();
    }
}
