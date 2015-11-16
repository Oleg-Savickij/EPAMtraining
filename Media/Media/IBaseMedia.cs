using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media
{
    public interface IBaseMedia
    {
          TimeSpan Duration { get;  }
          DateTime CreationDate { get;  }
          Rate Rating { get;  }
    }
}
