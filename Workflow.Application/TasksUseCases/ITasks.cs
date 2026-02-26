using Workflow.Domain;

namespace Workflow.Application.TasksUseCases
{
    public interface ITasks
    {
        Task<IEnumerable<TasksEntity>> GetAllAsync(StateEntity state);
        Task<IEnumerable<TasksEntity>> GetAllAsync(PriorityEntity priority);
        Task<IEnumerable<TasksEntity>> GetAllAsync(StateEntity state, PriorityEntity priority);
    }
}
