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

        public async Task<IEnumerable<TasksEntity>> ExecuteAsync(PriorityEntity priority)
        {
            return await _repository.GetAllAsync(priority);
        }
    }
}
