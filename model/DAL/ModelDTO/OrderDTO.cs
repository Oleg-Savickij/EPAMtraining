﻿using DAL.ModelDTO;
using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelDTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public double Sum { get; set; }
        public virtual int ManagerId {get;set;}
    }
}
