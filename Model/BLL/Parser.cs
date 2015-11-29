using DAL;
using System;
using System.Collections.Generic;
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
            var manager = new DAL.ModelDTO.ManagerDTO { AddDate = DateTime.ParseExact(fileName[3].Substring(0, 8), "ddMMyyyy", Thread.CurrentThread.CurrentCulture), Name = fileName[2] };
            string[] record;
            using (StreamReader file = new StreamReader(path))
            {
                while(!file.EndOfStream)
                {
                    record = file.ReadLine().Split(';');
                    uow.Managers.Add(manager);
                    uow.Orders.Add(new DAL.Model.OrderDTO {Date=DateTime.Parse(record[0]),Client=record[1],Product=record[2],Sum=double.Parse(record[3]) });
                }
                uow.Save();
                uow.Dispose();
            }
        }
    }
}
