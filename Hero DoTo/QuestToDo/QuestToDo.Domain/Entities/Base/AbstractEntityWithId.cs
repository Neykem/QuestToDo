namespace QuestToDo.Domain.Entities.Base
{
    public abstract class AbstractEntityWithId<T> : IBaseEntity
    {
        public required object Id { get; set; }
        public  DateTime CreatedDate { get; set; }
        public  DateTime? ModifiedDate { get; set; }
        public  DateTime? DeletedDate { get; set; }
    }
}
