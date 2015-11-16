using EPAM_laba_2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model
{
    public class Word : ISentenceItem, IWord
    {
        private Symbol[] symbols;

        public Word(string chars)
        {
            if (chars != null)
            {
                this.symbols = chars.Select(x => new Symbol(x)).ToArray();
            }
        }

        public Symbol this[int index]
        {
            get
            {
                return symbols[index];
            }
        }

        public string chars
        {
            get
            {
                string word="";
                foreach (var item in symbols)
                {
                    word += item.Chars;
                }
                return word;
            }
        }

        public string Chars
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var s in this.symbols)
                {
                    sb.Append(s.Chars);
                }
                return sb.ToString();
            }
        }

        public int Length
        {
            get
            {
                return symbols.Length;
            }
        }
        public bool IsFirstVowel
        {
            get
            {
                bool triger = false;
                string buffer = "QEUIOAYqeyuioajJ";
                if (buffer.Contains(symbols[0].Chars)) triger = true;
                else triger = false;
                return triger;
            }
        }
       
    }
}
