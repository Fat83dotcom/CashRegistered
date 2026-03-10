using System.Linq.Expressions;

namespace Shared.Abstractions;

public interface IRepository<T> where T : BaseEntity
{
    // Alterado de AddAsync para CreateAsync
    Task CreateAsync(T entity);
    
    Task<T?> GetByIdAsync(int id);
    
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    
    void Update(T entity);
    
    void Delete(T entity);
}