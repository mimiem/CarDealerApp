using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using CarDealer.Models.BindingModels;

namespace CarDealer.Services
{
    public class CustomersService : Service
    {
        public IEnumerable<Customer> GetOrderedCustomers(string order)
        {
            IEnumerable<Customer> orderedCustomers = new List<Customer>();

            if (order == "ascending")
            {
                orderedCustomers = context.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .ToList();
            }

            if (order == "descending")
            {
                orderedCustomers = context.Customers
                    .OrderByDescending(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .ToList();
            }

            return orderedCustomers;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> customers = this.context.Customers;
            return customers;
        }

        public CustomerTotalSalesViewModel GetCustomerByGivenId(int id)
        {
            Customer customer = this.context.Customers.Find(id);

            CustomerTotalSalesViewModel model = new CustomerTotalSalesViewModel()
            {
                Name = customer.Name,
                CarsCount = customer.Sales.Count,
                SpentMoney = customer.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
            };

            return model;
        }

        public void AddCustomer(CustomerBindingModel model)
        {
            Customer newCustomer = new Customer()
            {
                Name = model.Name,
                BirthDate = model.BirthDate,
                IsYoungDriver=IsYoungDriverOrNot(model.BirthDate)
            };

            this.context.Customers.Add(newCustomer);
            this.context.SaveChanges();
        }

        public EditCustomerViewModel GetCustomerForEditByGivenId(int id)
        {
            Customer customer = this.context.Customers.Find(id);

            EditCustomerViewModel customerVM = new EditCustomerViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                BirthDate = customer.BirthDate
            };

            return customerVM;
        }

        public void EditCustomer(EditCustomerBM model)
        {
            Customer customer = this.context.Customers.Find(model.Id);

            if (customer == null)
            {
                throw new ArgumentNullException("There is not such customer");
            }

            customer.Name = model.Name;
            customer.BirthDate = model.BirthDate;
            this.context.SaveChanges();
        }

        private bool IsYoungDriverOrNot(DateTime birthDate)
        {

            int age = DateTime.Now.Year - birthDate.Year;

            if (age < 30)
            {
                return true;
            }

            return false;
        }
    }
}
