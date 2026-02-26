using System.Linq.Expressions;
using Workflow.Domain;
using Workflow.Infrastructure.Data.Models;

namespace Workflow.Infrastructure.Data.Mappings
{
    internal static class TasksMappings
    {
        internal static Expression<Func<Tasks, TasksEntity>> ToDomain =>
            t => new TasksEntity(
                id: t.Id,
                name: t.Name,
                description: t.Description,
                stateCode: t.StateCode,
                priorityCode: t.PriorityCode);

        internal static Tasks ToModel(this TasksEntity t)
            => new Tasks
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                StateCode = t.StateCode,
                PriorityCode = t.PriorityCode,
            };
    }
}
