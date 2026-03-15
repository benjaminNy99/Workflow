using Workflow.Application.DTOs.TasksDtos;
using Workflow.Application.TasksUseCases;

namespace Workflow.Web.Api.Endpoints
{
    public static class TasksEndpoints
    {
        public static void MapTasksEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/tasks")
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

            group.MapPost("/", async (AddTasksDto dto, AddTasks useCase) =>
            {
                try
                {
                    var task = await useCase.ExecuteAsunc(dto);
                    return Results.Created($"/api/taks/{task.Id}", task);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex.Message);
                }
            }).WithName("AddTasks")
            .WithSummary("Crea una nueva tarea")
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

            group.MapPut("/{id:guid}", async (Guid id, UpdateTasksDto dto, UpdateTasks useCase) =>
            {
                try
                {
                    var tasks = await useCase.ExecuteAsunc(dto, id);
                    return Results.Ok(tasks);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex.Message);
                }
            }).WithName("UpdateTasks")
            .WithDescription("Actualiza los datos de una tarea")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
