namespace CarDealer.Services
{
    using global::Services;
    using Models.EntityModels;
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels;
    using Models.BindingModels;
    using System;

    public class CarsService : Service
    {
        public IEnumerable<Car> GetOrderedCars(string make)
        {
            IEnumerable<Car> cars = new List<Car>();

            if (make== null)
            {
                cars = this.context.Cars;
            }
            else
            {
                cars = this.context.Cars
                    .Where(c => c.Make == make)
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .ToList();
            }

            return cars;
        }

        public IEnumerable<Car> GetAllCars()
        {
            IEnumerable<Car> cars = this.context.Cars;

            return cars;
        }

        public CarPartsViewModel GetCarPartsByGivenId(int id)
        {
            Car car = context.Cars.Find(id);

            CarViewModel carView = new CarViewModel()
            {
                Make = car.Make,
                Model = car.Model,
                TravelledDistance = car.TravelledDistance
            };

            IEnumerable<PartViewModel> parts = car.Parts.Select(p => new PartViewModel()
            {
                Name = p.Name,
                Price = p.Price
            });

            CarPartsViewModel carParts = new CarPartsViewModel()
            {
                Car = carView,
                Parts = parts
            };

            return carParts;
        }

        public void AddCar(AddCarBM bind)
        {
            Car car = new Car()
            {
                Make = bind.Make,
                Model = bind.Model,
                TravelledDistance = bind.TravelledDistance
            };

            int[] partsIds = bind.Parts.Split(' ').Select(int.Parse).ToArray();

            foreach (var partId in partsIds)
            {
                Part part = this.context.Parts.Find(partId);
                car.Parts.Add(part);
            }

            this.context.Cars.Add(car);
            this.context.SaveChanges();
        }
    }
}
