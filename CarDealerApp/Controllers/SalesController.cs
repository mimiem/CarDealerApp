namespace CarDealerApp.Controllers
{
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.ViewModels;
    using CarDealer.Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;
        public SalesController()
        {
            this.service = new SalesService();
        }

        [HttpGet]
        [Route]
        public ActionResult All()
        {
            IEnumerable<SaleViewModel> salesVM = this.service.GetAllSales();

            return View(salesVM);
        }
        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include ="CarMake, CarModel, Customer, Discount")] AddSaleBM model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddSale(model);
                return this.RedirectToAction("All"); 
            }

            return this.View();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult About(int id)
        {
            SaleViewModel saleView = this.service.GetSaleByGivenId(id);

            return View(saleView);
        }

        [HttpGet]
        [Route("discounted/{percent?}")]
        public ActionResult Discounted(double? percent)
        {
            IEnumerable<SaleViewModel> salesV = this.service.GetAllSalesWithGivenDiscount(percent);
            
            return View(salesV);
        }
    }
}