using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public interface ITasks
    {
        Task<IEnumerable<Tasks>> GetAllAsync(State state);
        Task<IEnumerable<Tasks>> GetAllAsync(Priority priority);
        Task<IEnumerable<Tasks>> GetAllAsync(State state, Priority priority);
    }
}
