using System.Linq.Expressions;

namespace CargoTrackingSystem.Domain.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> All { get; }
    IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
    T? Find(params object[] keyValues);
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    Task<T?> FindByAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync();
    void Add(T entity);
    void Edit(T entity);
    void Delete(T entity);
    void Save();
    Task SaveAsync();
    void Upsert(T entity, Func<T, bool> predicate);
    void Dispose();
}