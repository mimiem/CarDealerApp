using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using CarDealer.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("customers")]
    public class CustomersController : Controller
    {
        private CustomersService service;
        public CustomersController()
        {
            this.service = new CustomersService();
        }

        //[HttpGet]
        //[Route("all")]
        //public ActionResult All()
        //{
        //    IEnumerable<Customer> customers = this.service.GetAllCustomers();
        //    return this.View(customers);
        //}

        [HttpGet]
        [Route("all/{order:regex(ascending|descending)}")]
        public ActionResult All(string order)  
        {
            IEnumerable<Customer> orderedCustomers = this.service.GetOrderedCustomers(order);

            return View(orderedCustomers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetCustomerById(int id)
        {
            CustomerTotalSalesViewModel model = this.service.GetCustomerByGivenId(id);

            return View(model);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            ViewBag.Users = new User[]
            {
                new User() { Id = 1, Name = "Frank Miller", Age = 35,Email="frank@gmail.com", IsSubscribed = true },
                new User() { Id = 2, Name = "Zoe Zandana", Age = 30,Email="zoe@gmail.com", IsSubscribed = false },
                new User() { Id = 3, Name = "Joe Doe", Age = 35,Email="joe@gmail.com", IsSubscribed = true }
            };

            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, BirthDate")] CustomerBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCustomer(model);

                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View();
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            EditCustomerViewModel customer = this.service.GetCustomerForEditByGivenId(id);

            return this.View(customer);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Name, BirthDate")] EditCustomerBM model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditCustomer(model);

                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View(this.service.GetCustomerForEditByGivenId(model.Id));
        }
    }
}