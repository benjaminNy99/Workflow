using Workflow.Application.Services;
using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class GetTasksById
    {
        private readonly IRepository<Tasks, Guid> _repository;

        public GetTasksById(IRepository<Tasks, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Tasks?> ExecuteAsync(Guid id)
        {
            var tasks = await _repository.GetAsync(id);

            return tasks;
        }
    }
}
