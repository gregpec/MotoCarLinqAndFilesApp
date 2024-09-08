using MotoAppmod4App.Data.Entities;

namespace MotoAppmod4App.Data.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
    }
}
