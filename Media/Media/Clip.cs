using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media
{
    class Clip : BaseMedia, IClip
    {
        public string Quality { get; set; }
        
    }
}
