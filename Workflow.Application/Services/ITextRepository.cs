namespace Workflow.Application.Services
{
    public interface ITextRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllAsync(string text);
    }
}
