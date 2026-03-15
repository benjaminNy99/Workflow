namespace Workflow.Application.Services
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity?> GetAsync(TId id);
        Task AddAsync(TEntity entity);
        Task UpdateAsunc(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
