using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class DeleteTasks
    {
        private readonly IRepository<TasksEntity, Guid> _repository;

        public DeleteTasks(IRepository<TasksEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var tasks = await _repository.GetAsync(id);
            if (tasks is null)
            {
                throw new InvalidOperationException($"No se encontro a la tarea con el Id: {id}");
            }

            await _repository.DeleteAsync(tasks);
        }
    }
}
