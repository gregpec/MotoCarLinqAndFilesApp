
using MotoAppmod4App.Data.Entities;

namespace MotoAppmod4App.Components.DataProviders.Extensions;
public static class CarsHelper
{
    public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color) //wykorzystanie extention w prowiderze //Extention metod do linq - bez użycia LINQ chyaba
    {
        return query.Where(x => x.Color == color);
    }
}

