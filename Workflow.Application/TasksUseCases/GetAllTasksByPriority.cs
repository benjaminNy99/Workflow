using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class GetAllTasksByPriority
    {
        private readonly ITasks _repository;

        public GetAllTasksByPriority(ITasks repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tasks>> ExecuteAsync(Priority priority)
        {
            return await _repository.GetAllAsync(priority);
        }
    }
}
