﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineApplication.Library.Models.Binding
{
    [ExcludeFromCodeCoverage]
    public class AddSpin
    {
        public string Animals { get; set; }
        public bool BonusBall { get; set; }
        public string Prize { get; set; }
    }
}
