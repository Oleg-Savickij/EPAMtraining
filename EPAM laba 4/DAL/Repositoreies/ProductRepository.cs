using OrdersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository: IRepository<DAL.Models.Product>
    {
        public ProductRepository(OrdersModel.OrdersModel db)
        {
            this.context = db;
        }

        private OrdersModel.OrdersModel context;

        OrdersModel.Product ToEntity(DAL.Models.Product source)
        {
            return new OrdersModel.Product { Id = source.Id, Name = source.Name};
        }

        DAL.Models.Product ToObject(OrdersModel.Product source)
        {
            return new DAL.Models.Product { Id = source.Id, Name = source.Name };
        }
        public void Add(DAL.Models.Product entity)
        {
            context.Product.Add(ToEntity(entity));
        }

        public void Delete(DAL.Models.Product entity)
        {
            context.Product.Remove(ToEntity(entity));
        }

        public void DeleteAll(IEnumerable<DAL.Models.Product> entity)
        {
            foreach (var item in context.Product)
            {
                context.Product.Remove(item);
            }
        }

        public void Update(DAL.Models.Product entity)
        {
            var entry = context.Entry(entity);
            context.Product.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
