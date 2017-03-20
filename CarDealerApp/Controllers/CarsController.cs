namespace CarDealerApp.Controllers
{
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.EntityModels;
    using CarDealer.Models.ViewModels;
    using CarDealer.Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [RoutePrefix("cars")]
    [Route("{action}=index")]
    public class CarsController : Controller
    {
        private CarsService service;

        public CarsController()
        {
            this.service = new CarsService();
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<Car> cars = this.service.GetAllCars();

            return this.View(cars);
        }

        [HttpGet]
        [Route("{make?}")]
        public ActionResult Index(string make)
        {
            IEnumerable<Car> cars = this.service.GetOrderedCars(make);
            
            return View(cars);
        }

        [HttpGet]
        [Route("{id:int}/parts")]
        public ActionResult CarParts(int id)
        {
            CarPartsViewModel carParts = this.service.GetCarPartsByGivenId(id);

            return View(carParts);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Make, Model, TravelledDistance, Parts")] AddCarBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCar(bind);
                return this.RedirectToAction("Index");
            }

            return this.View();
        }
    }
}