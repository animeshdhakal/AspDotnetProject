using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatientApp.Data;

namespace PatientApp.Repository;

public class Repository<T>(ApplicationDbContext context) : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public Task<IQueryable<T>> GetAll()
    {
        return Task.FromResult(_dbSet.AsQueryable()); 
    }

    public async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> Get(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await Save();
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await Save();
    }

    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        await Save();
    }

    public async Task Save()
    {
        await context.SaveChangesAsync();
    }
}