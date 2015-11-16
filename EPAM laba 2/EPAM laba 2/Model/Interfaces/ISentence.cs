using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model.Interfaces
{
    public interface ISentence: ICollection<ISentenceItem>
    {
        ICollection<ISentenceItem> Items { get; }
        string TypeOfSentence();
        int Length { get; }
    }
}
