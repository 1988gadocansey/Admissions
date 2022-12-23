using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;
public class Repository<T>: IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    protected Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public int Count()
    {
        return _dbSet.Count();
    }

    public void Delete(object id)
    {
        var entity = Get(id);
        if (entity == null) return;
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }

    public T Get(object id)
    {
        var x = _dbSet.Find(id);
        return x;
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.AsEnumerable();
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}