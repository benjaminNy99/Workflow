using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class GetAllTasksByStatePriority
    {
        private readonly ITasks _repository;

        public GetAllTasksByStatePriority(ITasks repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TasksEntity>> ExecuteAsync(StateEntity state, PriorityEntity priority)
        {
            return await _repository.GetAllAsync(state, priority);
        }
    }
}
