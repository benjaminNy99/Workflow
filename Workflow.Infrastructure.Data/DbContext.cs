using Microsoft.EntityFrameworkCore;

namespace Workflow.Infrastructure.Data.Models
{
    public partial class Context
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
