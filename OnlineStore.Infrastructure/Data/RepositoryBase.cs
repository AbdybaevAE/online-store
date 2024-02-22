using Microsoft.EntityFrameworkCore;
using OnlineStore.Shared.Core;

namespace OnlineStore.Infrastructure.Data
{
    public class RepositoryBase<T>(DbContext dbContext) : IRepository<T> where T : class
    {
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().AddRange(entities);
            await dbContext.SaveChangesAsync(cancellationToken);
            return entities;
        }
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().UpdateRange(entities);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            dbContext.Set<T>().RemoveRange(entities);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken) where TId : notnull
        {
            return await dbContext.Set<T>().FindAsync([id], cancellationToken);
        }
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }
        public IQueryable<T> FindAll(CancellationToken cancellationToken)
        {
            return dbContext.Set<T>();
        }
    }
}
