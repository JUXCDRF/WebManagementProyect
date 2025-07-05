using System.Linq.Expressions;

namespace WebManagementProyect.ADomain.InterfacesRepository;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetAllQueryAsync();
    Task<bool> AddAsync(T entity);
    Task<T?> GetByIdAsync(Guid Id);
    Task<bool> DeleteAsync(Guid id, string motivo);
    Task<bool> SaveAsync();
}
