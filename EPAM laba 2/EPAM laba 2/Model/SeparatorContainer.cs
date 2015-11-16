using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model
{
    public class SeparatorContainer
    {
        private string[] sentenceSeparators = new string[] { ".", "?", "!", "...", "?!" };
        private string[] wordSeparators = new string[] { " ", "-" };

        public IEnumerable<string> SentenceSeparators ()
        {
            return sentenceSeparators.AsEnumerable();
        }

        public IEnumerable<string> WordSeparators()
        {
            return wordSeparators.AsEnumerable();
        }

    }
}
