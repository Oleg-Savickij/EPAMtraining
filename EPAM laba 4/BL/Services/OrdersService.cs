using BL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositoreies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace BL
{
    public class OrdersService: IService
    {
        private IUnitOfWork uow = new EFUnitOfWork();

        public void Dispose()
        {
            uow.Dispose();
        }

        public Order GetOrder(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void MakeOrder(Order item)
        {
            if (item != null)
            {
                uow.Orders.Add(item);
            }
            uow.Save();
        }
    }
}
