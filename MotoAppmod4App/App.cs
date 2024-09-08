namespace MotoAppmod4App;
using System.Diagnostics.Metrics;

using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using MotoAppmod4App.Components.CsvReader;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }
    public void Run()
    {
        UserCommunication();
    }
    public void CreateXmL()
    {
        var records = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var document = new XDocument();
        var cars = new XElement("Cars", records
            .Select(x =>
            new XElement("Car",
                new XAttribute("Name", x.Name),
                 new XAttribute("Combined", x.Combined),
                  new XAttribute("Manufacturer", x.Manufacturer))));
        document.Add(cars);
        document.Save("fuel.xml");
    }
    private void BMWCarXml()
    {
        string filePath = "fuel.xml";
        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("The file path is null or empty.");
            return;
        }
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"The file {filePath} does not exist.");
            return;
        }
        try
        {
            var document = XDocument.Load(filePath);
            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
                .Select(x => x.Attribute("Name")?.Value);
            if (names != null)
            {
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the XML file: {ex.Message}");
        }
    }
    private void GroupsCars()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        var groups = cars
            .GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Average = g.Average(c => c.Combined),
            })
            .OrderByDescending(x => x.Max);
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}");
            Console.WriteLine($"\t Max:{group.Max}");
            Console.WriteLine($"\t Average:{group.Average}");
        }
    }
    public void CarsManufacturer()
    {
        string filePath = "fuel.xml";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"The file {filePath} does not exist.");
            return;
        }
        try
        {
            var document = XDocument.Load(filePath);
            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
                .Select(x => x.Attribute("Name")?.Value);
            if (names != null)
            {
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the XML file: {ex.Message}");
        }
    }
    public void CarsInCountry()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        var carsInCountry = cars.Join(
            manufacturers,
            c => new { c.Manufacturer, c.Year },
            m => new { Manufacturer = m.Name, m.Year },
            (car, manufacturer) =>
            new
            {
                manufacturer.Country,
                car.Name,
                car.Combined
            })
            .OrderBy(x => x.Country)
            .ThenBy(x => x.Combined);

        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Country:{car.Country}");
            Console.WriteLine($"\t Name:{car.Name}");
            Console.WriteLine($"\t Average:{car.Combined}");
        }
        var document = new XDocument();
        var carss = new XElement("Cars", cars
            .Select(x =>
            new XElement("Car",
                new XAttribute("Name", x.Name),
                 new XAttribute("Combined", x.Combined),
                  new XAttribute("Manufacturer", x.Manufacturer))));
        document.Add(carss);
        document.Save("cars.xml");
    }
    private void XML()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        var document = new XDocument();
        var sortedManufacturers = manufacturers.OrderBy(m => m.Country).ToList();
        var xml = new XElement("Manufacturers",
           sortedManufacturers.Select(m => new XElement("Manufacturer",
               new XAttribute("Name", m.Name),
               new XAttribute("Country", m.Country),
               new XElement("Cars",
                   new XAttribute("country", m.Country),
                   new XAttribute("CombinedSum", cars.Where(c => c.Manufacturer == m.Name).Sum(c => c.Combined)),
                   cars.Where(c => c.Manufacturer == m.Name).Select(c =>
                       new XElement("Car",
                       new XAttribute("Model", c.Name),
                       new XAttribute("Combined", c.Combined)
                   ))
               )
           ))
       );
        document.Add(xml);
        document.Save("ModelsOfCarInCountry.xml");
        Console.WriteLine(xml);
    }
    private void ConsoleXML()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        {
            var sortedManufacturers = manufacturers.OrderBy(m => m.Country).ToList();
            foreach (var manufacturer in sortedManufacturers)
            {
                var manufacturerCars = cars.Where(c => c.Manufacturer == manufacturer.Name).ToList();
                int combinedSum = manufacturerCars
                       .Sum(c => c.Combined);
                Console.WriteLine($"\nManufacturer: {manufacturer.Name}, Country: {manufacturer.Country}");
                Console.WriteLine($"Combined sum: {combinedSum}");
                Console.WriteLine("--------------------------------------------------");

                foreach (var car in manufacturerCars)
                {
                    Console.WriteLine($"Model: {car.Name}, Year: {car.Year}, Combined: {car.Combined} ");
                }
                Console.WriteLine("--------------------------------------------------\n");
            }
        }
    }
    private void ManufacturersCarCombined()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        var groups = cars
            .GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Average = g.Average(c => c.Combined),
            })
            .OrderBy(x => x.Average);
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}");
            Console.WriteLine($"\t Max:{group.Max}");
            Console.WriteLine($"\t Average:{group.Average}");
        }
    }
    private void UserCommunication()
    {
        string input;
        do
        {
            TextColoring(ConsoleColor.Yellow, "Welcome to Aplication Commission App");
            Console.WriteLine("\n================= MENU Data Cars and Customers ================");
            Console.WriteLine("1. To create file fuel.XML");
            TextColoring(ConsoleColor.Green, "2. To create a cars group XML file by country, manufacturers and number of cars in the country and display the group of in the console based on the fuel.csv and manufacturers.csv files");
            TextColoring(ConsoleColor.Green, "3. To display a group of cars by country, name, manufacturer and number of cars in a country by manufacturer on the console ");
            Console.WriteLine("4. Create Group cars");
            Console.WriteLine("5. List BMW cars from file fuel.xml");
            Console.WriteLine("6. View manufacturers by cars combined");
            Console.WriteLine("7. View cars by country ");
            Console.WriteLine(" Press q to exit program: ");
            input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Creating file fuel.XML");
                    CreateXmL();
                    break;
                case "2":
                    {
                        TextColoring(ConsoleColor.DarkGreen, "\n- - Creating file XML - -");
                        Console.WriteLine("XML");
                        XML();
                    }
                    break;
                case "3":
                    {
                        TextColoring(ConsoleColor.DarkGreen, "\n- - Writing to console file XML - -");
                        Console.WriteLine("XML");
                        ConsoleXML();
                    }
                    break;
                case "4":
                    {
                        Console.WriteLine("4. Creating GropusCars XML");
                        GroupsCars();
                    }
                    break;
                case "5":
                    {
                        Console.WriteLine("5. List BMW car from file fuel.XML");
                        BMWCarXml();
                    }
                    break;
                case "6":
                    {
                        Console.WriteLine("Manufacturers Cars Combined");
                        ManufacturersCarCombined();
                    }
                    break;
                case "7":
                    {
                        TextColoring(ConsoleColor.DarkGreen, "\n- - to view Cars by Country - -");
                        CarsInCountry();
                    }
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        } while (input != "q");

        static void TextColoring(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}

