using System;
using System.Collections.Generic;
using System.Linq;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

namespace Services
{
    public class PartsService : Service
    {
        public void AddPart(AddPartBM model)
        {
            Part part = new Part()
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = 1,
                Supplier = this.context.Suppliers.FirstOrDefault(s => s.Name == model.Supplier)
            };

            this.context.Parts.Add(part);
            this.context.SaveChanges();
        }

        public IEnumerable<AllPartsViewModel> GetAllParts()
        {
            IEnumerable<AllPartsViewModel> parts = this.context.Parts.Select(p => new AllPartsViewModel()
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                Supplier = p.Supplier
            });

            return parts;
        }

        public DeletePartViewModel GetDeletePartViewModelByGivenId(int id)
        {
            Part part = this.context.Parts.Find(id);

            DeletePartViewModel model = new DeletePartViewModel()
            {
                Id = part.Id,
                Name = part.Name,
                Price = part.Price
            };

            return model;
        }

        public void DeletePart(DeletePartBM model)
        {
            Part part = this.context.Parts.Find(model.Id);

            this.context.Parts.Remove(part);

            this.context.SaveChanges();

        }

        public EditPartViewModel GetEditPartViewModelByGivenId(int id)
        {
            Part part = this.context.Parts.Find(id);
            EditPartViewModel model = new EditPartViewModel()
            {
                Id = part.Id,
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity
            };

            return model;
        }

        public void EditPart(EditPartBM model)
        {
            Part part = this.context.Parts.Find(model.Id);
            part.Price = model.Price;
            part.Quantity = model.Quantity;
            this.context.SaveChanges();
        }
    }
}
