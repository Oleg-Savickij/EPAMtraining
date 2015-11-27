using System;
using System.Collections.Generic;
using System.IO;
using
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace LoadOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] new_order = new string[100] ;
            string[] dirs = Directory.GetFiles(@"Orders for load","*.csv");
            
            var file = new StreamReader(dirs[0]);
            var csv = new CsvReader(file);
            csv.GetRecord<RecordInfo>
            Console.WriteLine(new_order[0]);
        }
    }
}
