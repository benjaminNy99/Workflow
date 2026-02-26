using Workflow.Application.DTOs.Tasks;
using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class AddTasks
    {
        private readonly IRepository<TasksEntity, Guid> _repository;

        public AddTasks(IRepository<TasksEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<TasksEntity> ExecuteAsunc(TasksDto dto)
        {
            TasksEntity tasks;
            if (dto.Id.HasValue)
                tasks = new TasksEntity(
                    dto.Id.Value,
                    dto.Name,
                    dto.Description,
                    dto.StateCode,
                    dto.PriorityCode);
            else
                tasks = new TasksEntity(
                    dto.Name,
                    dto.Description,
                    dto.StateCode,
                    dto.PriorityCode);

            await _repository.AddAsync(tasks);
            return tasks;
        }
    }
}
