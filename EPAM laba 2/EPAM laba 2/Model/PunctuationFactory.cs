using EPAM_laba_2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model
{
    public class PunctuationFactory : ISentenceItemFactory
    {       
        public ISentenceItem Create(string chars)
        {
            return new PunctuationMark(chars);
        }
    }
}
