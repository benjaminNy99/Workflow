namespace Workflow.Application.Services
{
    public interface ICodeRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(int code);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
