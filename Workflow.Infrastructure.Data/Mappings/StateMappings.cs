using System.Linq.Expressions;
using Workflow.Domain;
using Workflow.Infrastructure.Data.Models;

namespace Workflow.Infrastructure.Data.Mappings
{
    internal static class StateMappings
    {
        internal static Expression<Func<State, StateEntity>> ToDomain =>
            s => new StateEntity(
                code: s.Code,
                description: s.Description);

        internal static State ToModel(this StateEntity s)
            => new State
            {
                Code = s.Code,
                Description = s.Description,
            };
    }
}
