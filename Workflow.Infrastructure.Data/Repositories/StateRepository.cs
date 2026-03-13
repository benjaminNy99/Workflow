using Microsoft.EntityFrameworkCore;
using Workflow.Application.Services;
using Workflow.Domain;
using Workflow.Infrastructure.Data.Mappings;
using Workflow.Infrastructure.Data.Models;

namespace Workflow.Infrastructure.Data.Repositories
{
    public sealed class StateRepository : ICodeRepository<StateEntity>
    {
        private readonly Context _context;

        public StateRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StateEntity>> GetAllAsync()
        {
            return await _context.State
                .Select(StateMappings.ToDomain)
                .ToListAsync();
        }

        public async Task<StateEntity?> GetAsync(int code)
        {
            return await _context.State
                .Where(s => s.Code == code)
                .Select(StateMappings.ToDomain)
                .SingleOrDefaultAsync();
        }
    }
}
