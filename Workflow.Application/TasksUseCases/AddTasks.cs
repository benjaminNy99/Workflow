using Workflow.Application.DTOs.TasksDtos;
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

        public async Task<TasksEntity> ExecuteAsunc(AddTasksDto dto)
        {
            TasksEntity tasks = new TasksEntity(
                dto.Name,
                dto.Description,
                dto.StateCode,
                dto.PriorityCode);

            await _repository.AddAsync(tasks);
            await _repository.SaveChangesAsync();
            return tasks;
        }
    }
}
