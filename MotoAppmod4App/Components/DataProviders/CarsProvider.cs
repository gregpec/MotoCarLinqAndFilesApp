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
            var colors = cars.Select(x => x.Color).Distinct().ToList(); //unikatowe kolory IUnerable to List trzeba fać
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
            // wyciaganie danych do klasy anonimowej
        }
        public string AnonymousClass()
        {
            var cars = _carsRepository.GetAll(); // tworzenie metod animowych roboczo poewne informache na potzreby ondormacji użycie selecta;

            var list = cars.Select(car => new
            {
                Identifier = car.Id,
                ProductName = car.Name,
                ProductSize = car.Type
            });

            //przeiterowanie 
            StringBuilder sb = new(2048);
            foreach (var car in list)
            {
                sb.AppendLine($"Product ID: {car.Identifier}");
                sb.AppendLine($"Product ID: {car.ProductName}");
                sb.AppendLine($"Product ID: {car.ProductSize}");
            }
            return sb.ToString();
        }

        //sortowanie
        public List<Car> OrderByName()

        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.Name).ToList(); //OrderBy - metoda zdefiniowana
        }

        public List<Car> OrderByNameDescending()

        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(x => x.Name).ToList(); // odwrócenie kolejnosci
        }

        public List<Car> OrderByColorAndName()

        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Color) //sortowanie po kolorze
                .ThenBy(x => x.Name)  //sortowanie po nazwie
                .ToList();      // sortowanie po ...

        }

        public List<Car> OrderByColorAndNameDesc()

        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderByDescending(x => x.Color) //sortowanie po kolorze odwrocenienie
                .ThenByDescending(x => x.Name)  //sortowanie po nazwie
                .ToList();      // sortowanie po ...
        }
        //where
        public List<Car> WhereStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
        }

        public List<Car> WhereStartsWithAndCostIsGraterThan(string prefix, decimal cost)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList(); //where z dwoma warunkami 
        }
        public List<Car> WhereColorIs(string color)  // [rzeniesienie do extention metod implementujac IEnumerable
        {
            //wykorzystanie extentions chyba robienie tego samego na wiele sposobów
            var cars = _carsRepository.GetAll();
            return cars.ByColor("Red").ToList(); // extension metod do LINQ
        }

        public Car FirstByColor(string color)  //pierwszy samochód danego koloru  zwraca exception gdy niema samochodu danego koloru
        {
            var cars = _carsRepository.GetAll();
            return cars.First(x => x.Color == color);

        }

        public Car? FirstOrDefaultByColor(string color)
        {

            var cars = _carsRepository.GetAll();  //może być nullem zwraca null w przypadku braku samochodu danego koloru ten sam kod ale z /?/
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
            return cars.Last(x => x.Color == color); //zamiast First używamy last
        }

        public Car SingleById(int id)
        {
            var cars = _carsRepository.GetAll();
            return cars.Single(x => x.Id == id);
        }

        public Car? SingleOrDefaultById(int id)
        {
            var cars = _carsRepository.GetAll();
            return cars.SingleOrDefault(x => x.Id == id); //id nie istnieje default zwraca null
        }


        //take
        public List<Car> TakeCars(int howMany)
        {
            var cars = _carsRepository.GetAll(); // można raz napisać ale gdy system rozproszony za kazdym racem 
            return cars
                .OrderBy(x => x.Name)
                .Take(howMany)
                .ToList();
        }

        public List<Car> TakeCars(Range range) // przetłumaczenie LINQ funkcja range 
        {
            var cars = _carsRepository.GetAll(); // można raz napisać ale gdy system rozproszony za kazdym racem 
            return cars
                .OrderBy(x => x.Name)
                .Take(2..7)
                .ToList();
        }

        public List<Car> TakeCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll(); // można raz napisać ale gdy system rozproszony za kazdym racem 
            return cars
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<Car> SkipCars(int howMany)
        {
            var cars = _carsRepository.GetAll(); // można raz napisać ale gdy system rozproszony za kazdym racem 
            return cars
                .OrderBy(x => x.Name) //połączenie skipa i take robi pageing pominie ilosci stron i wyswietlenie kolejnych page up page down
                .Skip(howMany)
                .ToList();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll(); // można raz napisać ale gdy system rozproszony za kazdym racem 
            return cars
                .OrderBy(x => x.Name)
                .SkipWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<string> DistinctAllColors()
        {
            var cars = _carsRepository.GetAll(); // można raz napisać ale gdy system rozproszony za kazdym racem 
            return cars
                .Select(x => x.Color)
                .Distinct()
                .OrderBy(c => c)  //posortowanie po na nazwie doszlsmy z order by
                .ToList();

            //podobne do get unique cod   List<string> GetUnqiueCarColors()
        }

        public List<Car> DistinctByColors()  // na obiektach 
        {
            //   List<string> GetUnqiueCarColors()

            var cars = _carsRepository.GetAll(); // można raz napisać ale gdy system rozproszony za kazdym racem 
            return cars
                .DistinctBy(x => x.Color)
                .OrderBy(c => c.Color)  //posortowanie po na nazwie doszlsmy z order by
                .ToList();
        }

        public List<Car[]> ChunkCars(int size) // zwraca list tablic o okreslonej wielkosci 
        {
            var cars = _carsRepository.GetAll();
            return cars.Chunk(size).ToList(); // wysylanie danych paczkami 
        }


    }
}

