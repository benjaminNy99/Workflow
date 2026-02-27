using Workflow.Application.TasksUseCases;

namespace Workflow.Web.Api.Endpoints
{
    public static class TasksEndpoints
    {
        public static void MapTasksEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/taks")
                .WithTags("Tasks Entity");

            group.MapGet("/{id:guid}", async (Guid id, GetTasksById useCase) =>
            {
                try
                {
                    var tasks = await useCase.ExecuteAsync(id);
                    if (tasks is null) throw new InvalidOperationException($"No se ha podico encontrar la tarea con id: {id}");

                    return Results.Ok(tasks);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
            }).WithName("GetTasksById")
            .WithDescription("Obtener una tarea por medio de su Id")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
