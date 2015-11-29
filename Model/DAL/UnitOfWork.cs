using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.ModelDTO;

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
            db.SaveChanges();
        }
    }
}
