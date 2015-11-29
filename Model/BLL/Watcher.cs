using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Watcher
    {
        private Parser parser = new Parser();
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private TaskFactory tasks = new TaskFactory();

        public Watcher()
        {
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
            tasks.StartNew(() => parser.Parse(path));
        }
    }
}
