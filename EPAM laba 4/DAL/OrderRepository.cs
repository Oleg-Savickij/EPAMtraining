using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderRepository: IRepository<Order>
    {
        private OrdersModel.OrdersModel context = new OrdersModel.OrdersModel();

        OrdersModel.Order ToEntity(DAL.Models.Order source)
        {
            return new OrdersModel.Order { Id = source.Id, Client=source.Client,Sum=source.Sum,Seller_Id=source.Seller.Id,Product_Id=source.Product.Id };
        }

        DAL.Models.Order ToObject(OrdersModel.Order source)
        {
            return new DAL.Models.Order { Id = source.Id, Client = source.Client, Sum = source.Sum, Product=new Product { Id = source.Id, Name = source.Product.Name }, Seller=new Seller { Id = source.Id, Name = source.Seller.Name } };
        }
        public void Add(Order entity)
        {
            context.Order.Add(ToEntity(entity));
        }

        public void Delete(Order entity)
        {
            context.Order.Remove(ToEntity(entity));
        }

        public void DeleteAll(IEnumerable<Order> entity)
        {
            foreach (var item in context.Order)
            {
                context.Order.Remove(item);
            }
        }

        public void Update(Order entity)
        {
            var entry = context.Entry(entity);
            context.Order.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
