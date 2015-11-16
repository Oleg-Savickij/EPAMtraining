using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.ATS
{
    public class PhoneNumber: IEquatable<PhoneNumber>
    {
        private string _phoneNumber;
        public PhoneNumber(string number)
        {
            this._phoneNumber = number;
        }

        public string Value
        {
            get
            {
                return _phoneNumber;
            }          
        }

        public bool Equals(PhoneNumber other)
        {
            return this._phoneNumber == other._phoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj is PhoneNumber)
            {
                return this._phoneNumber == ((PhoneNumber)obj)._phoneNumber;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return _phoneNumber.GetHashCode();
        }

       /* public static bool operator ==(PhoneNumber p1, PhoneNumber p2)
        {
            return (p1 as IEquatable<PhoneNumber>).Equals(p2);
        }

        public static bool operator !=(PhoneNumber p1, PhoneNumber p2)
        {
            return !(p1 == p2);
        }*/
    }
}
