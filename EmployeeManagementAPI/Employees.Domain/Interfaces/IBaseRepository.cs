namespace Employees.Domain.Interfaces
{
    public interface IBaseRepository<T, TId> where T : class
    {
        Task<T?> GetByIdAsync(TId id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
