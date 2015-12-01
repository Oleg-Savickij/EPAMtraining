using DAL.Unit_Of_Work;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Watcher
    {        
        private FileSystemWatcher watcher = new FileSystemWatcher();
        TaskFactory tf = new TaskFactory();
        private Parser p;

        public Watcher()
        {
            UnitOfWork uow = new UnitOfWork();
            p = new Parser(uow);
            watcher.Path = ConfigurationManager.AppSettings.Get("FolderPath");
            watcher.Filter = ConfigurationManager.AppSettings["FileExtension"];

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            var path = e.FullPath;
            tf.StartNew(() => p.Parse(path));
        }
    }
}
