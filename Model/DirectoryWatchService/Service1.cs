using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatchService
{
    public partial class Service1 : ServiceBase
    {
        private Watcher watcher;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            watcher = new Watcher();
        }

        protected override void OnStop()
        {
        }
    }
}
