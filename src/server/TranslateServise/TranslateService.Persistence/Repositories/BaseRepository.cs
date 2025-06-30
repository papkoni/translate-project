using Microsoft.EntityFrameworkCore;
using TranslateService.Persistence.Abstractions;
using TranslateService.Persistence.Abstractions.Repositories;
namespace TranslateService.Persistence.Repositories;

public class BaseRepository<T>(
    IApplicationDbContext context): IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }
    
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}