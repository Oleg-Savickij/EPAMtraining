﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model.Interfaces
{
    public interface ISentenceItemFactory
    {
        ISentenceItem Create(string chars);
    }
}
