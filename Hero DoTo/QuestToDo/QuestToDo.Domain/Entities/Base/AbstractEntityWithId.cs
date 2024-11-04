using System.ComponentModel.DataAnnotations;

namespace QuestToDo.Domain.Entities.Base
{
	public abstract class AbstractEntityWithId<T> : IBaseEntity
	{
		public required T Id { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime CreatedDate { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime? ModifiedDate { get; set; }
	}
}
