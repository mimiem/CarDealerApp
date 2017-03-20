namespace CarDealer.Services
{
    using System.Collections.Generic;
    using Models.ViewModels;
    using global::Services;
    using System.Linq;
    using Models.BindingModels;
    using System;
    using Models.EntityModels;
    public class SuppliersService : Service
    {
        public IEnumerable<SupplierViewModel> GetAllSuppliersByGivenType(string type)
        {
            IEnumerable<SupplierViewModel> suppliers = new List<SupplierViewModel>();

            if (type == "local")
            {
                suppliers = context.Suppliers
                    .Where(s => s.IsImporter == false)
                    .Select(s => new SupplierViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        PartsCount = s.Parts.Count
                    });
                return suppliers;
            }
            else
            {
                suppliers = context.Suppliers
                    .Where(s => s.IsImporter == true)
                    .Select(s => new SupplierViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        PartsCount = s.Parts.Count
                    });
                return suppliers;
            }

        }

        public void AddSupplier(AddSupplierBM model)
        {
            Supplier supplier = new Supplier()
            {
                Name = model.Name,
                IsImporter = model.IsImporter
            };

            int[] partsIds = model.Parts.Split(' ').Select(int.Parse).ToArray();

            foreach (var partId in partsIds)
            {
                Part part = this.context.Parts.Find(partId);
                supplier.Parts.Add(part);
            }

            this.context.Suppliers.Add(supplier);
            this.context.SaveChanges();
        }
    }
}
