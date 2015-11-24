using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Class1
    {
        private ProductRepository _products = new ProductRepository();
        public void add(Product item)
        {
            _products.Add(item);
        }
    }
}
