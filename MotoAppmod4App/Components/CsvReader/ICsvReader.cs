using MotoAppmod4App.Components.CsvReader.Models;
namespace MotoAppmod4App.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);
        List<Manufacturer> ProcessManufacturer(string filePath);
    }
}
