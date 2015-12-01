using DAL.Model;
using EPAM_laba_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClientRepository : IRepository<ClientDTO>
    {
        private orders_Entities context;

        public ClientRepository(orders_Entities db)
        {
            context = db;
        }
        Client ToEntity(ClientDTO entity)
        {
            return new Client { SecondName = entity.Name, Id = entity.Id };
        }
        ClientDTO ToObject(Client entity)
        {
            return new ClientDTO { Name = entity.SecondName, Id = entity.Id };
        }
        public void Add(ClientDTO entity)
        {
            var e = ToEntity(entity);
            context.Client.Add(e);
        }

        public void Delete(ClientDTO entity)
        {
            var e = ToEntity(entity);
            context.Client.Remove(e);
        }

        public ClientDTO Get(int id)
        {
            var e = context.Client.FirstOrDefault(x => x.Id == id);
            return ToObject(e);
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            return context.Client.Select(x => ToObject(x));
        }

        public ClientDTO GetByName(string Name)
        {
            return ToObject(context.Client.FirstOrDefault(x => x.SecondName == Name));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(ClientDTO entity)
        {
            var entry = context.Entry(entity);
            context.Client.Attach(ToEntity(entity));
            entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
