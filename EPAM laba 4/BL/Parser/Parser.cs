using CsvHelper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Parser
{
    public class Parser
    {
        ICollection<Order> _orders = new List<Order>();
        ICollection<Product> _products = new List<Product>();
        ICollection<Seller> _sellers = new List<Seller>();
        OrdersService ordersService = new OrdersService();
        string fileName;
        string[] newOrders;
        public Parser(string FileName,string[] NewOrder)
        {
            this.fileName = FileName;
            this.newOrders = NewOrder;
        }

        public void Parse()
        {
            string[] dirs = Directory.GetFiles(@"Orders for load", "*.csv");

            var file = new StreamReader(dirs[0]);
            var csv = new CsvReader(file);
            var record = csv.GetRecord<RecordInfo>();

            string[] order;
            string[] Seller = this.SplitFileName(fileName);
            for (int i=0;i<newOrders.Length;i++)
            {

                order = newOrders[0].Split(',');
                var newOrder = new Order { }
            }
        }

        public string[] SplitFileName(string fileName)
        {
            return fileName.Split('_');
        }
    }
}
