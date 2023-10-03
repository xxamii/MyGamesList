using Core.Models;

namespace DatabaseLayer.Abstractions
{
    public interface IRepository<T>
        where T : Entity
    {
        Task<List<T>> GetEntities(Func<T, bool> filter);
        Task CreateEntity(T entity);
        Task UpdateEntity(T entity);
        Task DeleteEntity(T entity);
    }
}
