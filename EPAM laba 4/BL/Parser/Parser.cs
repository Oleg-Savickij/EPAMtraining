using BL.Interfaces;
using CsvHelper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace BL.Parser
{
    public class Parser
    {
        private IService service;
        public RecordInfo ParseFileName(string CurrentPath)
        {
            string[] fileName = CurrentPath.Split('_');
            
            return new RecordInfo { Seller = fileName[0], Date = DateTime.ParseExact(fileName[1].Substring(0, 8), "ddMMyyyy", Thread.CurrentThread.CurrentCulture) };
        }

        //public List<RecordInfo> ParseFile(string )

        public void Parse(string fileName)
        {
            service = new OrdersService();
            var file = new StreamReader(fileName);
            var csv = new CsvReader(file).GetRecords<RecordInfo>().ToList();
            
            var FileNameInformation = ParseFileName(fileName);
            AddSellerToDB(FileNameInformation);
            
            foreach (var item in csv)
            {
                var order = new Order { Client = item.Client, Sum = item.Sum, Product = new Product { Name = item.Product }, Seller = new Seller { Name = FileNameInformation.Seller } };
                service.MakeOrder(order);
            }
            service.Save();
            service.Dispose();
        }

        public IEnumerable<RecordInfo> ParseFile(CsvReader file)
        {
            var records = file.GetRecords<RecordInfo>();
            return records;
        }
        public void AddSellerToDB(RecordInfo record)
        {
            var seller = new Seller { Name = record.Seller };
            
            service.AddSeller(seller);
        }

       
    }
}
