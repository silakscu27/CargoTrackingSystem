using CargoTrackingSystem.Domain.Repositories;
using CargoTrackingSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CargoTrackingSystem.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> All => _dbSet;

    public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _dbSet;
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return query;
    }

    public T? Find(params object[] keyValues)
    {
        return _dbSet.Find(keyValues);
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public async Task<T?> FindByAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Edit(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Upsert(T entity, Func<T, bool> predicate)
    {
        var existing = _dbSet.FirstOrDefault(predicate);
        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(entity);
        }
        else
        {
            _dbSet.Add(entity);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}