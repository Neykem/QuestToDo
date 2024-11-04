using System.ComponentModel.DataAnnotations;

namespace QuestToDo.Domain.Entities.Base
{
    public interface IBaseEntity
    {
        [Required]
        public object Id { get; set; }

        [DataType(DataType.DateTime)]
        DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? ModifiedDate { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? DeletedDate { get; set; }
    }
    public interface IBaseEntity<T> : IBaseEntity
    {
        T Id { get; set; }
    }
}
