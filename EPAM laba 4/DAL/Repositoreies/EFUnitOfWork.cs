using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositoreies
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private OrdersModel.OrdersModel db = new OrdersModel.OrdersModel();
        private ProductRepository productRepository;
        private SellerRepository sellerRepository;
        private OrderRepository orderRepository;

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository==null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }

        public IRepository<Seller> Sellers
        {
            get
            {
                if(sellerRepository==null)
                {
                    sellerRepository = new SellerRepository(db);
                }
                return sellerRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
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
    }
}
