namespace Workflow.Application.Services
{
    public interface IPersistent
    {
        Task SaveChangesAsync();
    }
}
