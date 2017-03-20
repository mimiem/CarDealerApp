namespace CarDealerApp.Controllers
{
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.ViewModels;
    using CarDealer.Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;
        public SuppliersController()
        {
            this.service = new SuppliersService();
        }

        [HttpGet]
        [Route("{type:regex(local|importers)}")]
        public ActionResult Index(string type)
        {
            IEnumerable<SupplierViewModel> suppliers = this.service.GetAllSuppliersByGivenType(type);

            return View(suppliers);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include ="Name, IsImporter, Parts")] AddSupplierBM model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddSupplier(model);
                return this.RedirectToAction("Index", new { type = "local" });
            }

            return this.View();
        }
    }
}