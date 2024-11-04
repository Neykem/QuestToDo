using System.Linq.Expressions;
using QuestToDo.Domain.Entities.Base;

namespace QuestToDo.Persistence.Repo.Interface
{
    /// <summary>
    /// Base Generic Read Only Repository
    /// </summary>
    public interface IReadOnlyRepository
    {
        Task<ICollection<Entity>> Get<Entity>(
            Expression<Func<Entity, bool>>? filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>>? orderBy = null,
            CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity;

        Task<Entity> GetOne<Entity>(
            Expression<Func<Entity, bool>>? filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>>? orderBy = null,
            CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity;

        Task<int> GetCount<Entity>(
            Expression<Func<Entity, bool>>? filter = null,
            CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity;

        Task<bool> CheckOfExist<Entity>(
            Expression<Func<Entity, bool>>? filter = null,
            CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity;
    }
}
