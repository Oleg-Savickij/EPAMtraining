using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SellerRepository : IRepository<Seller>
    {
        private OrdersModel.OrdersModel context;
        public SellerRepository(OrdersModel.OrdersModel db)
        {
            this.context = db;
            Mapper.CreateMap<OrdersModel.Seller, Seller>();
            Mapper.CreateMap<Seller, OrdersModel.Seller > ();
        }

        OrdersModel.Seller ToEntity (DAL.Models.Seller source)
        {
            return new OrdersModel.Seller { Id = source.Id, Name = source.Name };
        }

        DAL.Models.Seller ToObject(OrdersModel.Seller source)
        {
            return new DAL.Models.Seller { Id = source.Id, Name = source.Name };
        }
        public void Add(Seller entity)
        {
            context.Seller.Add(Mapper.Map<Seller, OrdersModel.Seller>(entity));
        }

        public void Delete(Seller entity)
        {
            context.Seller.Remove(ToEntity(entity));
        }

        public void DeleteAll(IEnumerable<Seller> entity)
        {
            foreach (var item in context.Seller)
            {
                context.Seller.Remove(item);
            }
        }
        
        public void Update(Seller entity)
        {
            var entry = context.Entry(entity);
            context.Seller.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
