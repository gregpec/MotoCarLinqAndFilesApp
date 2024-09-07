using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoAppmod4App.Components.CsvReader;
using MotoAppmod4App.Components.CsvReader.Extensions;
using MotoAppmod4App.Components.CsvReader.Models;

namespace MotoAppmod4App.Components.CsvReader;

public class CsvReader:ICsvReader
{
    public List<Car> ProcessCars(string filePath)
    {

    if (!File.Exists(filePath)) 
        {
            return new List<Car>();
        }
        var cars = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToCar()
            ;
        return cars.ToList();
    }

    //public List<Manufacturer> ProcessManufacturer(string filePath)
    //{
    //    throw new NotImplementedException();
    //}


    public List<Manufacturer> ProcessManufacturer(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacturer>();
        }
        var manufacturers = File
          .ReadAllLines(filePath)
          .Where(x => x.Length > 1)
          .Select(x =>        //select bez extension
          {
              var columns = x.Split(',');
              return new Manufacturer()
              {
                  Name = columns[0],
                  Country = columns[1],
                  Year = int.Parse(columns[2])
              };
          });

        return manufacturers.ToList();
    }
    
}

