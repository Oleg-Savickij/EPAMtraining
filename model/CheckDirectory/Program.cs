
using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CheckDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskFactory tf = new TaskFactory();
            Parser p = new Parser();
            string[] files = Directory.GetFiles(@"D:\TestFolder\", "*.csv");
            foreach (var item in files)
            {
                tf.StartNew(() =>p.Parse(Path.GetFullPath(item)));
            }
            

            
        }
    }
}
