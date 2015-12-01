using DAL.Model;
using EPAM_laba_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerRepository : IRepository<ManagerDTO>
    {
        private orders_Entities context;

        public ManagerRepository(orders_Entities db)
        {
            context = db;
        }
        Manager ToEntity(ManagerDTO entity)
        {
            return new Manager { SecondName = entity.Name, Id = entity.Id };
        }
        ManagerDTO ToObject(Manager entity)
        {
            return new ManagerDTO { Name = entity.SecondName, Id = entity.Id };
        }
        public void Add(ManagerDTO entity)
        {
            var e = ToEntity(entity);
            context.Manager.Add(e);
        }

        public void Delete(ManagerDTO entity)
        {
            var e = ToEntity(entity);
            context.Manager.Remove(e);
        }

        public ManagerDTO Get(int id)
        {
            var e = context.Manager.FirstOrDefault(x => x.Id == id);
            return ToObject(e);
        }

        public IEnumerable<ManagerDTO> GetAll()
        {
            return context.Manager.Select(x => ToObject(x));
        }

        public ManagerDTO GetByName(string Name)
        {
            return ToObject(context.Manager.FirstOrDefault(x => x.SecondName == Name));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(ManagerDTO entity)
        {
            var entry = context.Entry(entity);
            context.Manager.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
