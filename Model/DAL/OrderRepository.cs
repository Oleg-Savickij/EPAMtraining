using DAL.Model;
using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderRepository : IRepository<OrderDTO>
    {
        private DBModel.Model context;

        public OrderRepository(DBModel.Model db)
        {
            context = db;
        }

        private Orders ToEntity(OrderDTO source)
        {
            return new Orders { Id=source.Id,Client=source.Client,Date=source.Date,Product=source.Product,Sum=source.Sum,Manager_Id=source.Manager.Id };
        }

        private OrderDTO ToObject(Orders source)
        {
            return new OrderDTO { Id = source.Id, Client = source.Client, Date = source.Date, Product = source.Product, Sum = source.Sum };
        }
        public void Add(OrderDTO entity)
        {
            var e = ToEntity(entity);
            context.Orders.Add(e);
        }

        public void Delete(OrderDTO entity)
        {
            var e = ToEntity(entity);
            context.Orders.Remove(e);
        }

        public OrderDTO Get(int id)
        {
            return ToObject(context.Orders.FirstOrDefault(item => item.Id == id));
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return context.Orders.Select(item => ToObject(item));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(OrderDTO entity)
        {
            var entry = context.Entry(entity);
            context.Orders.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
