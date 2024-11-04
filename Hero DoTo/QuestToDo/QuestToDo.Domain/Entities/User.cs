using QuestToDo.Domain.Entities.Base;

namespace QuestToDo.Domain.Entities
{
	public class User : AbstractEntityWithId<Guid>
	{
		public required string Login { get; set; }
		public required string PasswordHash { get; set; }
		public required string Salt { get; set; }
	}
}
