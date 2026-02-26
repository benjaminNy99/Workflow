using System.Linq.Expressions;
using Workflow.Domain;
using Workflow.Infrastructure.Data.Models;

namespace Workflow.Infrastructure.Data.Mappings
{
    internal static class PriorityMappings
    {
        internal static Expression<Func<Priority, PriorityEntity>> ToDomain =>
            p => new PriorityEntity(
                code: p.Code,
                description: p.Description);

        internal static Priority ToModel(this PriorityEntity p)
            => new Priority
            {
                Code = p.Code,
                Description = p.Description,
            };
    }
}
