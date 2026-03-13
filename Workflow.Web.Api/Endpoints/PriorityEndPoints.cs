using Workflow.Application.PriorityUseCases;

namespace Workflow.Web.Api.Endpoints
{
    public static class PriorityEndPoints
    {
        public static void MapPriorityEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/priority")
                .WithTags("Priority Entity");

            group.MapGet("/", async (GetAllPriority useCase) =>
            {
                try
                {
                    var priorities = await useCase.ExecuteAsync();
                    return Results.Ok(priorities);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex.Message);
                }
            }).WithName("GetAllPriority")
            .WithDescription("Obtener todas las prioridades")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
