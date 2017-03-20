using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.ViewModels
{
    public class CustomerTotalSalesViewModel
    {
        public string Name { get; set; }
        public int CarsCount { get; set; }
        public double? SpentMoney { get; set; }
    }
}
