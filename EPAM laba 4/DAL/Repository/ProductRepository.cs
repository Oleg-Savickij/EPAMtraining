using DAL.Model;
using EPAM_laba_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository:IRepository<ProductDTO>
    {
        private orders_Entities context;

        public ProductRepository(orders_Entities db)
        {
            context = db;
        }
        Product ToEntity(ProductDTO entity)
        {
            return new Product { Name = entity.Name, Id = entity.Id };
        }
        ProductDTO ToObject(Product entity)
        {
            return new ProductDTO { Name = entity.Name, Id = entity.Id };
        }
        public void Add(ProductDTO entity)
        {
            var e = ToEntity(entity);
            context.Product.Add(e);
        }

        public void Delete(ProductDTO entity)
        {
            var e = ToEntity(entity);
            context.Product.Remove(e);
        }

        public ProductDTO Get(int id)
        {
            var e = context.Product.FirstOrDefault(x => x.Id == id);
            return ToObject(e);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return context.Product.Select(x => ToObject(x));
        }

        public ProductDTO GetByName(string Name)
        {
            return ToObject(context.Product.FirstOrDefault(x => x.Name == Name));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(ProductDTO entity)
        {
            var entry = context.Entry(entity);
            context.Product.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
