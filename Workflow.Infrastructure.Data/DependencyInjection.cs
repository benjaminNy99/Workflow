using Microsoft.Extensions.DependencyInjection;
using Workflow.Application.PriorityUseCase;
using Workflow.Application.PriorityUseCases;
using Workflow.Application.Services;
using Workflow.Application.StateUseCades;
using Workflow.Application.TasksUseCases;
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

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<GetAllPriority>();
            services.AddScoped<GetPriorityByCode>();
            services.AddScoped<GetAllState>();
            services.AddScoped<GetStateByCode>();
            services.AddScoped<GetTasksById>();
            services.AddScoped<AddTasks>();
            services.AddScoped<UpdateTasks>();

            return services;
        }
    }
}
