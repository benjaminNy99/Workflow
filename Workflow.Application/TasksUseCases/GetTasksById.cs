using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class GetTasksById
    {
        private readonly IRepository<TasksEntity, Guid> _repository;

        public GetTasksById(IRepository<TasksEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<TasksEntity?> ExecuteAsync(Guid id)
        {
            var tasks = await _repository.GetAsync(id);

            return tasks;
        }
    }
}
