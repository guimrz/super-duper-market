namespace SuperDuperMarket.Core.EntityFrameworkCore.Abstractions
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        ValueTask<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);

        ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        ValueTask<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}