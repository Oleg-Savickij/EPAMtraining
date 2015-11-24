using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public double Sum { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Product Product { get; set; }

    }
}
