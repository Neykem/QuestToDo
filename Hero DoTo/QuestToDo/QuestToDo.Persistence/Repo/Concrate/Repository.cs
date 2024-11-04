using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuestToDo.Domain.Entities.Base;
using QuestToDo.Persistence.Repo.Interface;

namespace QuestToDo.Persistence.Repo.Concrate
{
    /// <summary>
    /// Base realization repository
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    internal class Repository<TContext> : IRepository, IDisposable where TContext : DbContext
    {
        readonly TContext _context;
        private IList<IBaseEntity> _entities { get; }
        private bool _disposed;

        public Repository(
            TContext context,
            IList<IBaseEntity> entities)
        {
            _context = context;
            _entities = entities;
        }

        protected EntityEntry<TEntity> GetTrackedEntity<TEntity>(TEntity entity)
            where TEntity : class, IBaseEntity
        {
            var entries = new List<EntityEntry<TEntity>>(_context.ChangeTracker.Entries<TEntity>());
            var trackedEntity = entries.SingleOrDefault(e => e.Entity.Id.Equals(entity.Id));

            return trackedEntity;
        }

        void IRepository.Delete<Entity>(
            Entity entity, bool hardDelete, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return;

            if (hardDelete)
            {
                _context.Remove(entity);
            }
            else
            {
                entity.DeletedDate = DateTime.UtcNow;
                _context.Update(entity);
            }
        }

        async Task IRepository.Save(CancellationToken cancellationToken)
            => await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        void IRepository.Add<Entity>(Entity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                return;

            _entities.Add(entity);
        }

        void IRepository.Update<Entity>(Entity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                return;

            entity.ModifiedDate = DateTime.UtcNow;
            var trackedEntity = GetTrackedEntity(entity);

            if (trackedEntity == null)
                _context.Entry(entity).State = EntityState.Modified;
            else if (trackedEntity.State != EntityState.Added)
                trackedEntity.State = EntityState.Modified;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
        }
    }
}
