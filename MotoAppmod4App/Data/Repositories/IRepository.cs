namespace MotoAppmod4App.Data.Repositories;
using MotoAppmod4App.Data.Entities;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>

    where T : class, IEntity
{

}

