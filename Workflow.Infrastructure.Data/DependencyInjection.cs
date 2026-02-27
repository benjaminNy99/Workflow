using Microsoft.Extensions.DependencyInjection;
using Workflow.Application.Services;
using Workflow.Domain;
using Workflow.Infrastructure.Data.Repositories;

namespace Workflow.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<TasksEntity, Guid>, TasksRepository>();

            return services;
        }

        public static IServiceCollection AddCodeRepository(this IServiceCollection services)
        {
            services.AddScoped<ICodeRepository<PriorityEntity>, PriorityRepository>();
            services.AddScoped<ICodeRepository<StateEntity>, StateRepository>();

            return services;
        }
    }
}
