using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryWatchService
{
    public partial class Service1 : ServiceBase
    {
        private Watcher watcher;
        private TaskFactory tf = new TaskFactory();
        
        public Service1()
        {
            InitializeComponent();         
        }

     
        protected override void OnStart(string[] args)
        {
             tf.StartNew(()=>watcher = new Watcher());
            
        }

        protected override void OnStop()
        {
           
        }
     

    
    }
}
