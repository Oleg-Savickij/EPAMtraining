using Epam_Laba_3.ATS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Laba_3.Requests
{
    public class OutgoingRequest:Request
    {
        public PhoneNumber Target { get; set; }
    }
}
