﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] new_order = new string[100] ;
            string[] dirs = Directory.GetFiles(@"Orders for load","*.csv");
            
            foreach (var item in dirs)
            {
                new_order = File.ReadAllLines(item);
            }
            Console.WriteLine(new_order[0]);
        }
    }
}