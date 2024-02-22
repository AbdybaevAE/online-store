namespace OnlineStore.Shared.Core
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken) where TId : notnull;
        Task SaveChangesAsync(CancellationToken cancellationToken);
        IQueryable<T> FindAll(CancellationToken cancellationToken);
    }
}
