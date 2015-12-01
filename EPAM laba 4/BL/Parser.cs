using DAL.Model;
using DAL.Unit_Of_Work;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Parser
    {
        public IUnitOfWork uow;
        public Parser(UnitOfWork UOW)
        {
            uow = UOW;
        }
        public void Parse (string Path)
        {
            string[] managerName = Path.Split('\\', '.', '_');
            object locker = new object();

            var manager = new ManagerDTO { Name = managerName[managerName.Length - 3] };
            lock (locker)
            {
                if (uow.Managers.GetByName(manager.Name) == null)
                {
                    uow.Managers.Add(manager);
                    uow.Save();                  
                }
                manager = uow.Managers.GetByName(manager.Name);
            }
            

            string[] record;
            using (StreamReader file = new StreamReader(Path))
            {
                while (file.EndOfStream)
                {
                    record = file.ReadLine().Split(';');
                    lock (locker)
                    {
                        var product = new ProductDTO { Name = record[2] };
                        if (uow.Products.GetByName(record[2]) == null)
                        {
                            uow.Products.Add(product);
                            uow.Save();                  
                        }
                        product = uow.Products.GetByName(record[2]);

                        var client = new ClientDTO { Name = record[1] };
                        if(uow.Clients.GetByName(record[1])==null)
                        {
                            uow.Clients.Add(client);
                            uow.Save();
                        }
                        client = uow.Clients.GetByName(record[1]);

                        var order = new OrderDTO
                        {
                            Date = DateTime.Parse(record[0]),
                            Sum = double.Parse(record[3]),
                            ManagerId = manager.Id,
                            ClientId = client.Id,
                            ProductId = product.Id
                        };
                        uow.Orders.Add(order);
                        uow.Save();
                    }

                }
            }
        }
    }
}
