using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoAppmod4App.Components.CsvReader.Extensions;
using MotoAppmod4App.Components.CsvReader.Models;
using System.Globalization;






// zrobienie implementacji kiedy yielda nie ma

//dzieki yield nie musimy tego robic zwracac kolekcji robic dodatkowych kolekcji 

namespace MotoAppmod4App.Components.CsvReader.Extensions
{
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source) //stworzenie samochodu na podstawie jednego sourcea

        {
            foreach (var line in source)
            {
                //podział linii po przecinku string
                var columns = line.Split(',');

                /*
                
               int year;
if (int.TryParse(columns[0], out year))
{
    yield return new Car
    {
        Year = year,
        Manufacturer = columns[1],
        Name = columns[2],
        Displacement = double.Parse(columns[3], CultureInfo.InvariantCulture),
        Cylinders = int.Parse(columns[4]),
        City = int.Parse(columns[5]),
        Highway = int.Parse(columns[6]),
        Combined = int.Parse(columns[7])
    };
}
else
{
    // Obsługa sytuacji, gdy konwersja nie powiodła się
    // Można na przykład zalogować błąd lub podjąć inną odpowiednią akcję
}

*/
                             
                yield return new Car 
                {
                    Year = int.Parse(columns[0]), 
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3], CultureInfo.InvariantCulture),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]), 
                    Combined = int.Parse(columns[7]) 
                };
                
            }







            // z chata 




            //foreach (var line in source)
            //{
            //    var columns = line.Split(',');

            //    if (columns.Length < 8)
            //    {
            //        // Skip lines that don't have the expected number of columns
            //        continue;
            //    }

            //    if (int.TryParse(columns[0], out int year) &&
            //        double.TryParse(columns[3], NumberStyles.Float, CultureInfo.InvariantCulture, out double displacement) &&
            //        int.TryParse(columns[5], out int cylinders) &&
            //        int.TryParse(columns[6], out int city) &&
            //        int.TryParse(columns[7], out int highway) &&
            //        int.TryParse(columns[8], out int combined))
            //    {
            //        yield return new Car
            //        {
            //            Year = year,
            //            Manufacturer = columns[1],
            //            Name = columns[2],
            //            Displacement = displacement,
            //            Cylinders = cylinders,
            //            City = city,
            //            Highway = highway,
            //            Combined = combined
            //        };
            //    }
            //    else
            //    {
            //        // Handle parsing error or log it
            //        // Optionally: yield break or throw exception if needed
            //    }
            //}




        }
    }
}
