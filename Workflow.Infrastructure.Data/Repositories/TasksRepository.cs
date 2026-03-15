using Microsoft.EntityFrameworkCore;
using Workflow.Application.Services;
using Workflow.Application.TasksUseCases;
using Workflow.Domain;
using Workflow.Infrastructure.Data.Mappings;
using Workflow.Infrastructure.Data.Models;

namespace Workflow.Infrastructure.Data.Repositories
{
    public sealed class TasksRepository : IRepository<TasksEntity, Guid>, ITasks
    {
        private readonly Context _context;

        public TasksRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(TasksEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            await _context.AddAsync(entity.ToModel());
        }

        public Task DeleteAsync(TasksEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.Remove(entity.ToModel());
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TasksEntity>> GetAllAsync(StateEntity state)
        {
            return await _context.Tasks
                .Where(t => t.StateCode == state.Code)
                .Select(TasksMappings.ToDomain)
                .ToListAsync();
        }

        public async Task<IEnumerable<TasksEntity>> GetAllAsync(PriorityEntity priority)
        {
            return await _context.Tasks
                .Where(t => t.PriorityCode == priority.Code)
                .Select(TasksMappings.ToDomain)
                .ToListAsync();
        }

        public async Task<IEnumerable<TasksEntity>> GetAllAsync(StateEntity state, PriorityEntity priority)
        {
            return await _context.Tasks
                .Where(t => t.StateCode == state.Code && t.PriorityCode == priority.Code)
                .Select(TasksMappings.ToDomain)
                .ToListAsync();
        }

        public async Task<TasksEntity?> GetAsync(Guid id)
        {
            return await _context.Tasks
                .Where (t => t.Id == id)
                .Select(TasksMappings.ToDomain)
                .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsunc(TasksEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.Update(entity.ToModel());
        }
    }
}
