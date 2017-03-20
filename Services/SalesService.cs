namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels;
    using Models.EntityModels;
    using global::Services;
    using Models.BindingModels;
    using System;

    public class SalesService : Service
    {
        public IEnumerable<SaleViewModel> GetAllSales()
        {
            IEnumerable<Sale> sales = context.Sales;

            IEnumerable<SaleViewModel> allSales = sales.Select(s => new SaleViewModel()
            {
                Car = s.Car,
                Customer = s.Customer,
                Price = s.Car.Parts.Sum(p => p.Price),
                Discount = s.Discount
            });
            return allSales;
        }

        public SaleViewModel GetSaleByGivenId(int id)
        {
            Sale sale = context.Sales.Find(id);
            SaleViewModel saleView = new SaleViewModel()
            {
                Car = sale.Car,
                Customer = sale.Customer,
                Price = sale.Car.Parts.Sum(p => p.Price),
                Discount = sale.Discount
            };

            return saleView;
        }

        public void AddSale(AddSaleBM model)
        {
            Sale sale = new Sale()
            {
                Car = this.context.Cars.FirstOrDefault(c => c.Make == model.CarMake && c.Model == model.CarModel),
                Customer = this.context.Customers.FirstOrDefault(c => c.Name == model.Customer),
                Discount = model.Discount
            };

            this.context.Sales.Add(sale);
            this.context.SaveChanges();
        }

        public IEnumerable<SaleViewModel> GetAllSalesWithGivenDiscount(double? percent)
        {
            IEnumerable<Sale> sales = context.Sales.Where(s => s.Discount != 0);

            if (percent != null)
            {
                percent /= 100;
                sales = sales.Where(s => s.Discount == percent);
            }

            IEnumerable<SaleViewModel> salesWithDiscount = sales.Select(s => new SaleViewModel()
            {
                Car = s.Car,
                Customer = s.Customer,
                Price = s.Car.Parts.Sum(p => p.Price),
                Discount = s.Discount
            });

            return salesWithDiscount;
        }
    }
}
