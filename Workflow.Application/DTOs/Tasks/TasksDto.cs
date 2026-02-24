namespace Workflow.Application.DTOs.Tasks
{
    public class TasksDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int StateCode { get; set; }
        public int PriorityCode { get; set; }
    }
}
