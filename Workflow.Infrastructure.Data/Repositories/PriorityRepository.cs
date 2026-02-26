using Microsoft.EntityFrameworkCore;
using Workflow.Application.Services;
using Workflow.Domain;
using Workflow.Infrastructure.Data.Mappings;
using Workflow.Infrastructure.Data.Models;

namespace Workflow.Infrastructure.Data.Repositories
{
    public sealed class PriorityRepository : ICodeRepository<PriorityEntity>
    {
        private readonly Context _context;

        public PriorityRepository(Context context)
        {
            _context = context;
        }

        public async Task<PriorityEntity?> GetAsync(int code)
        {
            return await _context.Priority
                .Where(p => p.Code == code)
                .Select(PriorityMappings.ToDomain)
                .SingleOrDefaultAsync();
        }
    }
}
