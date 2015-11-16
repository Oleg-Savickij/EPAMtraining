using EPAM_laba_2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model
{
    public class PunctuationMark :IPunctuationMark, ISentenceItem
    {
        private SeparatorContainer separators=new SeparatorContainer();
        private Symbol[] value;
        public Symbol[] Value
        {
            get
            {
                return value;
            }
        }


        public PunctuationMark(string chars)
        {
            if (chars != null)
            {
                this.value = chars.Select(x => new Symbol(x)).ToArray();
            }
        }

        public string chars
        {
            get
            {
                string punctuatonMark = "";
                foreach (var item in Value)
                {
                    punctuatonMark += item.Chars;
                }
                return punctuatonMark;
            }
        }
        
        public bool IsEndSentence
        {
            get
            {
                bool triger = false;
                foreach (var item in separators.SentenceSeparators())
                {
                    if (chars == item) triger = true;
                }
                return triger;
            }
        }

       
    }
}
