using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media
{
    public class Song : BaseMedia, IMedia, ISong
    {
        public string Name
        {
            get{return Name;}
            set{Name = value;}
        }
        public int BitRate { set; get;}
        public new TimeSpan Duration { get; set; }
        

      
    }
}
