﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.BindingModels
{
    public class AddSupplierBM
    {
        public string Name { get; set; }
        public bool IsImporter { get; set; }
        public string Parts { get; set; }
    }
}

