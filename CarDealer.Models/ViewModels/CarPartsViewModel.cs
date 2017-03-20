﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.ViewModels
{
    public class CarPartsViewModel
    {
        public CarViewModel Car { get; set; }
        public IEnumerable<PartViewModel> Parts { get; set; }
    }
}
