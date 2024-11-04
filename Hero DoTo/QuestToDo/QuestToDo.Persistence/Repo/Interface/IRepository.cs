using QuestToDo.Domain.Entities.Base;

namespace QuestToDo.Persistence.Repo.Interface
{
    /// <summary>
    /// Base interface Crud Repository
    /// </summary>
    public interface IRepository
    {
        void Add<Entity>(
            Entity entity,
            CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity;

        void Update<Entity>(
            Entity entity,
            CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity;

        void Delete<Entity>(
            Entity entity,
            bool hardDelete = false,
            CancellationToken cancellationToken = default)
            where Entity : class, IBaseEntity;

        Task Save(
            CancellationToken cancellationToken = default);
    }
}
