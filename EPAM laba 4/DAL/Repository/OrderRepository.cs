using DAL.Model;
using EPAM_laba_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderRepository:IRepository<OrderDTO>
    {
        private orders_Entities context;

        public OrderRepository(orders_Entities db)
        {
            context = db;
        }
        Order ToEntity(OrderDTO entity)
        {
            return new Order { Date=entity.Date, Id = entity.Id,Sum=entity.Sum,ManagerId=entity.ManagerId,ClientId=entity.ClientId,ProductId=entity.ProductId };
        }
        OrderDTO ToObject(Order entity)
        {
            return new OrderDTO { Date = entity.Date, Id = entity.Id, Sum = entity.Sum, ManagerId = entity.ManagerId, ClientId = entity.ClientId, ProductId = entity.ProductId };
        }
        public void Add(OrderDTO entity)
        {
            var e = ToEntity(entity);
            context.Order.Add(e);
        }

        public void Delete(OrderDTO entity)
        {
            var e = ToEntity(entity);
            context.Order.Remove(e);
        }

        public OrderDTO Get(int id)
        {
            var e = context.Order.FirstOrDefault(x => x.Id == id);
            return ToObject(e);
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return context.Order.Select(x => ToObject(x));
        }

        public OrderDTO GetByName(string Name)
        {
            return ToObject(context.Order.FirstOrDefault(x => x.Sum.ToString() == Name));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(OrderDTO entity)
        {
            var entry = context.Entry(entity);
            context.Order.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
