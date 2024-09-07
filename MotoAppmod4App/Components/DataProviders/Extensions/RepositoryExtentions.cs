using MotoAppmod4App.Data.Entities;
using MotoAppmod4App.Data.Repositories;

namespace MotoAppmod4App.Components.DataProviders.Extensions;

public static class RepositoryExtentions
{
    public static void AddBatch<T>(this IRepository<T> repository, T[] items) // fofanie słówka this do klasy static
     where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }
        repository.Save();

        // narazie nie generyczna metoda
    }

    public static void AddBatch<T>(this string s, T[] items) // fofanie słówka this do klasy static
    where T : class, IEntity
    {
        // narazie nie generyczna metoda
    }

}