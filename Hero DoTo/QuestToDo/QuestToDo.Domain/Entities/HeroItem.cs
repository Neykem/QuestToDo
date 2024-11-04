using QuestToDo.Domain.Entities.Base;

namespace QuestToDo.Domain.Entities
{
	public class HeroItem : AbstractEntityWithId<Guid>
	{
		public Guid HeroId { get; set; }
		public string? Description { get; set; }
	}
}
