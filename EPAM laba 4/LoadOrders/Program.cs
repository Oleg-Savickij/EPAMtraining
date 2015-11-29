using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using BL.Parser;

namespace LoadOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] new_order = new string[100] ;
            string[] dirs = Directory.GetFiles(@"Orders for load","*.csv");
            
            Parser parser = new Parser();
            foreach (var item in dirs)
            {
                parser.Parse(Path.GetFullPath(item));
            }
           
            Console.WriteLine(new_order[0]);
        }
    }
}
