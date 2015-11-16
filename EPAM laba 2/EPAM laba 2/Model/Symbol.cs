using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2
{
    public struct Symbol
    {
        private string chars;
        

        public string Chars
        {
            get { return chars; }
            private set { chars = value; }
        }

        public bool IsUpperCase
        {
            get
            {
                return chars != null && chars.Length > 0 && Char.IsLetter(chars[0]) && Char.IsUpper(chars[0]);
            }
        }

        public bool IsLowerCase
        {
            get
            {
                return chars != null && chars.Length > 0 && Char.IsLetter(chars[0]) && Char.IsLower(chars[0]);
            }
        }

        public Symbol(char source) : this()
        {
            this.chars = String.Format("{0}", source);
        }
    }
}
