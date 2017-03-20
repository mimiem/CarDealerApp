using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("parts")]
    public class PartsController : Controller
    {
        private PartsService service;

        public PartsController()
        {
            this.service = new PartsService();
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AllPartsViewModel> parts = this.service.GetAllParts();
            return this.View(parts);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, Price, Count, Supplier")] AddPartBM model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddPart(model);

                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            DeletePartViewModel model = this.service.GetDeletePartViewModelByGivenId(id);

            return this.View(model);
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "Id")] DeletePartBM model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeletePart(model);

                return this.RedirectToAction("All");
            }

            DeletePartViewModel deleteModel = this.service.GetDeletePartViewModelByGivenId(model.Id);

            return this.View(deleteModel);
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            EditPartViewModel model = this.service.GetEditPartViewModelByGivenId(id);
            return this.View(model);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Price, Quantity")] EditPartBM model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditPart(model);
                return this.RedirectToAction("All");
            }
            EditPartViewModel modelVM = this.service.GetEditPartViewModelByGivenId(model.Id);

            return this.View(modelVM);
        }
    }
}