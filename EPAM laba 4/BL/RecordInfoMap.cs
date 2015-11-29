using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public sealed class RecordInfoMap: CsvClassMap<RecordInfo>
    {
        public RecordInfoMap()
        {
            Map(m => m.Date).Name("");
        }
    }
}
