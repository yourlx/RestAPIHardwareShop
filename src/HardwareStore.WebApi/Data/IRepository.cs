namespace HardwareStore.WebApi.Data;

public interface IRepository<T>
{
    Task AddAsync(T item);

    Task<IEnumerable<T>> GetAsync();
    
    Task<T> GetAsync(Guid id);

    Task UpdateAsync(T item);
    
    Task DeleteAsync(Guid id);
}