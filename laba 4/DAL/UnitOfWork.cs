using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ModelDTO;
using System.Data.Entity.Validation;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBModel.Model db = new DBModel.Model();
        private ManagerRepository managerRepository;
        private OrderRepository orderRepository;
        public IRepository<ManagerDTO> Managers
        {
            get
            {
                if (managerRepository == null)
                {
                    managerRepository = new ManagerRepository(db);
                }
                return managerRepository;
            }
        }

        public IRepository<OrderDTO> Orders
        {
            get
            {
                if(orderRepository==null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            
        }
    }
}
