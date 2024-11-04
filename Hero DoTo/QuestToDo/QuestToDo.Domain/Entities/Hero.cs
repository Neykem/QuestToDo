using QuestToDo.Domain.Entities.Base;

namespace QuestToDo.Domain.Entities
{
	public class Hero : AbstractEntityWithId<Guid>
	{
		public Guid UserId { get; set; } 
		public required string Name { get; set; }
		public int Level { get; set; }
		public IEnumerable<HeroItem> Inventory { get; set; } = new List<HeroItem>();
	}
}
