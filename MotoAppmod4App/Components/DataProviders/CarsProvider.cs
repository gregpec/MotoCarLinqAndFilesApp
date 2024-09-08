using System.Text;
using MotoAppmod4App.Components.DataProviders.Extensions;
using MotoAppmod4App.Data.Entities;
using MotoAppmod4App.Data.Repositories;

namespace MotoAppmod4App.Components.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;

        public CarsProvider(IRepository<Car> carRepository)
        {
            _carsRepository = carRepository;
        }
        public List<string> GetUnqiueCarColors()
        {
            var cars = _carsRepository.GetAll();
            var colors = cars.Select(x => x.Color).Distinct().ToList();
            return colors;
        }
        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            cars.Select(x => x.Color).Distinct().ToList();
            return cars.Select(x => x.ListPrice).Min();
        }
        public List<Car> GetSpecificColumns()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new Car
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
            }).ToList();
            return list;
       
        }
        public string AnonymousClass()
        {
            var cars = _carsRepository.GetAll(); 

            var list = cars.Select(car => new
            {
                Identifier = car.Id,
                ProductName = car.Name,
                ProductSize = car.Type
            });
            StringBuilder sb = new(2048);
            foreach (var car in list)
            {
                sb.AppendLine($"Product ID: {car.Identifier}");
                sb.AppendLine($"Product ID: {car.ProductName}");
                sb.AppendLine($"Product ID: {car.ProductSize}");
            }
            return sb.ToString();
        }
        public List<Car> OrderByName()

        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.Name).ToList(); 
        }

        public List<Car> OrderByNameDescending()

        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(x => x.Name).ToList(); 
        }
        public List<Car> OrderByColorAndName()

        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Color) 
                .ThenBy(x => x.Name)  
                .ToList();    
        }
        public List<Car> OrderByColorAndNameDesc()

        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderByDescending(x => x.Color) 
                .ThenByDescending(x => x.Name) 
                .ToList();    
        }
        public List<Car> WhereStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
        }

        public List<Car> WhereStartsWithAndCostIsGraterThan(string prefix, decimal cost)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList(); 
        }
        public List<Car> WhereColorIs(string color)  
        {          
            var cars = _carsRepository.GetAll();
            return cars.ByColor("Red").ToList(); 
        }

        public Car FirstByColor(string color)  
        {
            var cars = _carsRepository.GetAll();
            return cars.First(x => x.Color == color);

        }

        public Car? FirstOrDefaultByColor(string color)
        {

            var cars = _carsRepository.GetAll(); 
            return cars.FirstOrDefault(x => x.Color == color);
        }

        public Car FirstOrDeafultByColorWithDefault(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .FirstOrDefault(
                x => x.Color == color,
                new Car { Id = -1, Name = "NOT FOUND" });
        }

        public Car LastByColor(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.Last(x => x.Color == color); 
        }

        public Car SingleById(int id)
        {
            var cars = _carsRepository.GetAll();
            return cars.Single(x => x.Id == id);
        }

        public Car? SingleOrDefaultById(int id)
        {
            var cars = _carsRepository.GetAll();
            return cars.SingleOrDefault(x => x.Id == id); 
        }


        //take
        public List<Car> TakeCars(int howMany)
        {
            var cars = _carsRepository.GetAll(); 
            return cars
                .OrderBy(x => x.Name)
                .Take(howMany)
                .ToList();
        }
        public List<Car> TakeCars(Range range) 
        {
            var cars = _carsRepository.GetAll(); 
            return cars
                .OrderBy(x => x.Name)
                .Take(2..7)
                .ToList();
        }

        public List<Car> TakeCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll(); 
            return cars
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<Car> SkipCars(int howMany)
        {
            var cars = _carsRepository.GetAll(); 
            return cars
                .OrderBy(x => x.Name) 
                .Skip(howMany)
                .ToList();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll(); 
            return cars
                .OrderBy(x => x.Name)
                .SkipWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<string> DistinctAllColors()
        {
            var cars = _carsRepository.GetAll(); 
            return cars
                .Select(x => x.Color)
                .Distinct()
                .OrderBy(c => c) 
                .ToList();
        }

        public List<Car> DistinctByColors() 
        {           
            var cars = _carsRepository.GetAll(); 
            return cars
                .DistinctBy(x => x.Color)
                .OrderBy(c => c.Color)  
                .ToList();
        }

        public List<Car[]> ChunkCars(int size) 
        {
            var cars = _carsRepository.GetAll();
            return cars.Chunk(size).ToList(); 
        }
    }
}

