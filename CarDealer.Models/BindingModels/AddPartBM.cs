using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.BindingModels
{
    public class AddPartBM
    {
        public string Name { get; set; }
        public double? Price { get; set; }
        public int? Count { get; set; }
        public string Supplier { get; set; }
    }
}
