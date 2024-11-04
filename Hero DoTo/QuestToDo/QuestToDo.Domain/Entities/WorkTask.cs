using QuestToDo.Domain.Entities.Base;
using QuestToDo.Domain.Entities.Enums.WorkTask;

namespace QuestToDo.Domain.Entities
{
    public class WorkTask : AbstractEntityWithId<Guid>
	{
		public required string Name { get; set; }
		public string? Description { get; set; }
		public Guid UserId { get; set; }
		public  DateTime? DeadLineDate {  get; set; } 
		public TaskComplexityEnum ComplexityLevel { get; set; } 
		public TaskPriorityEnum PriorityLevel {  get; set; }
		public bool IsCompleted { get; set; }
		public TaskStatusEnum Status {  get; set; }  
		public IEnumerable<WorkTask> SubTasks { get; set; } = new List<WorkTask>();
	}
}
