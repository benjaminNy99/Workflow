using Workflow.Application.DTOs.Tasks;
using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class AddTasks
    {
        private readonly IRepository<Tasks, Guid> _repository;

        public AddTasks(IRepository<Tasks, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Tasks> ExecuteAsunc(TasksDto dto)
        {
            Tasks tasks;
            if (dto.Id.HasValue)
                tasks = new Tasks(
                    dto.Id.Value,
                    dto.Name,
                    dto.Description,
                    dto.StateCode,
                    dto.PriorityCode);
            else
                tasks = new Tasks(
                    dto.Name,
                    dto.Description,
                    dto.StateCode,
                    dto.PriorityCode);

            await _repository.AddAsync(tasks);
            return tasks;
        }
    }
}
