using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;

namespace SuperDuperMarket.Core.EntityFrameworkCore
{
    public class Repository<TEntity>(DbContext dbContext) : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext dbContext = Throw.IfNull(dbContext);

        public IQueryable<TEntity> Entities => dbContext.Set<TEntity>();

        public async ValueTask<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityEntry<TEntity> entry = await dbContext.AddAsync(entity, cancellationToken);

            return entry.Entity;
        }

        public ValueTask<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityEntry entry = dbContext.Remove(entity);

            return ValueTask.FromResult(entry.State == EntityState.Deleted);
        }

        public ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityEntry<TEntity> entry = dbContext.Update(entity);

            return ValueTask.FromResult(entry.Entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}