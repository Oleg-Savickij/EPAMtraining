using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media
{
    public abstract class BaseMedia:IBaseMedia
    {
        public TimeSpan Duration { get; set; }
        public DateTime CreationDate { get; set; }
        public Rate Rating { get; set; }
    }
}
