namespace Workflow.Application.DTOs.TasksDtos
{
    public class AddTasksDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int StateCode { get; set; }
        public int PriorityCode { get; set; }
    }
}
