using Core.Models;

namespace DatabaseLayer.Abstractions
{
    public interface IRepository<T>
        where T : Entity
    {
        Task<List<T>> GetEntities(Func<T, bool>? filter = null);
        Task<T> CreateEntity(T entity);
        Task<T> UpdateEntity(T entity);
        Task DeleteEntity(T entity);
    }
}
