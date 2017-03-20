using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.BindingModels
{

    public class AddSaleBM
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string Customer { get; set; }
        public double Discount { get; set; }
    }
}
