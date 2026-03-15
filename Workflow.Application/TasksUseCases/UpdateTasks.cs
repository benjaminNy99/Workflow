using Workflow.Application.DTOs.TasksDtos;
using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public class UpdateTasks
    {
        private readonly IRepository<TasksEntity, Guid> _repository;

        public UpdateTasks(IRepository<TasksEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<TasksEntity> ExecuteAsunc(UpdateTasksDto dto, Guid id)
        {
            var tasks = await _repository.GetAsync(id);
            if (tasks is null)
            {
                throw new ArgumentException("La terea no existe");
            }

            tasks.ChangeData(dto.Name, dto.Description);
            await _repository.UpdateAsunc(tasks);
            await _repository.SaveChangesAsync();

            return tasks;
        }
    }
}
