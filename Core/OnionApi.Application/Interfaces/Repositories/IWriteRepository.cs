using OnionApi.Domain.Common;

namespace OnionApi.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class,IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entitIES);
        Task<T> UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
    }
}
