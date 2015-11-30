using DAL.ModelDTO;
using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerRepository : IRepository<ManagerDTO>
    {
        private DBModel.Model context;

        public ManagerRepository(DBModel.Model db)
        {
            context = db;
        }

        private static Managers ToEntity(ManagerDTO source)
        {
            return new Managers { Name = source.Name };
        }

        private ManagerDTO ToObject(Managers source)
        {
            return new ManagerDTO { Name = source.Name, Id = source.Id };
        }
        public void Add(ManagerDTO item)
        {
            var e = ToEntity(item);
            context.Managers.Add(e);
        }

        public void Delete(ManagerDTO item)
        {
            var e = ToEntity(item);
            context.Managers.Remove(e);
        }

        public ManagerDTO Get(int id)
        {
            return ToObject(context.Managers.FirstOrDefault(item => item.Id == id));
        }

        public IEnumerable<ManagerDTO> GetAll()
        {
            var managers = context.Managers.Select(item => ToObject(item));
            return managers;
        }

        public void Update(ManagerDTO entity)
        {
            var entry = context.Entry(entity);
            context.Managers.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public ManagerDTO GetByName(string Name)
        {
            var manager = context.Managers.FirstOrDefault(x => x.Name == Name);
            return ToObject(manager);
        }
    }
}
