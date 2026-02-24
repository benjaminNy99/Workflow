using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public sealed class GetAllTasksByState
    {
        private readonly ITasks _repository;

        public GetAllTasksByState(ITasks repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tasks>> ExecuteAsync(State state)
        {
            return await _repository.GetAllAsync(state);
        }
    }
}
