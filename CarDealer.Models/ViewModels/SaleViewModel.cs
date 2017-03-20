using CarDealer.Models.EntityModels;

namespace CarDealer.Models.ViewModels
{
    public class SaleViewModel
    {
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public double? Price { get; set; }
        public double Discount { get; set; }
    }
}
