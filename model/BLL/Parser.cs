using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class Parser
    {
        private IUnitOfWork uow = new UnitOfWork();
        public void Parse(string path)
        {
            string[] fileName = path.Split('\\', '_', '.');
            var manager = new DAL.ModelDTO.ManagerDTO {  Name = fileName[2] };
            var efManager = uow.Managers.GetByName(manager.Name);
            try {
                if (efManager == null)
                {
                    uow.Managers.Add(manager);
                    uow.Save();
                    efManager = uow.Managers.GetByName(manager.Name);
                }
            }
            catch (DataException)
            {
                Console.WriteLine("Enable to save manager.");
            }
            string[] record;
            using (StreamReader file = new StreamReader(path))
            {
                while(!file.EndOfStream)
                {
                    record = file.ReadLine().Split(';');
                    try {
                        uow.Orders.Add(new DAL.ModelDTO.OrderDTO { Date = DateTime.Parse(record[0]).Date, Client = record[1], Product = record[2], Sum = double.Parse(record[3]), ManagerId = efManager.Id });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wrong order information");
                    }
                }
                
                    uow.Save();
                
                
                
                uow.Dispose();
            }
        }
    }
}
