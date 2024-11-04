using Microsoft.EntityFrameworkCore;
using QuestToDo.Domain.Entities.Base;
using QuestToDo.Persistence.Repo.Interface;
using System.Linq.Expressions;

namespace QuestToDo.Persistence.Repo.Concrate
{
    /// <summary>
    /// Realization Read Only Repository with input context as TContext
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    internal class ReadOnlyRepository<TContext> : IReadOnlyRepository where TContext : DbContext
    {
        private readonly TContext _context;

        public ReadOnlyRepository(
            TContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<Entity> CreateQuery<Entity>(
            Expression<Func<Entity, bool>>? filter = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>>? orderBy = null, CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity
        {
            IQueryable<Entity> query = _context.Set<Entity>();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        async Task<ICollection<Entity>> IReadOnlyRepository.Get<Entity>(
            Expression<Func<Entity, bool>>? filter, Func<IQueryable<Entity>, IOrderedQueryable<Entity>>? orderBy, CancellationToken cancellationToken) 
                => await CreateQuery(filter, orderBy, cancellationToken).ToListAsync(cancellationToken).ConfigureAwait(false);

        async Task<Entity> IReadOnlyRepository.GetOne<Entity>(
            Expression<Func<Entity, bool>>? filter, Func<IQueryable<Entity>, IOrderedQueryable<Entity>>? orderBy, CancellationToken cancellationToken) 
                => await CreateQuery(filter, orderBy, cancellationToken).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        async Task<int> IReadOnlyRepository.GetCount<Entity>(
            Expression<Func<Entity, bool>>? filter, CancellationToken cancellationToken) 
                => await CreateQuery(filter, null, cancellationToken).CountAsync(cancellationToken).ConfigureAwait(false);

        async Task<bool> IReadOnlyRepository.CheckOfExist<Entity>(
            Expression<Func<Entity, bool>>? filter, CancellationToken cancellationToken) 
                => await CreateQuery(filter).AnyAsync(cancellationToken).ConfigureAwait(false);
    }
}