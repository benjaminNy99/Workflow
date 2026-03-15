using Workflow.Application.DTOs.StateDtos;
using Workflow.Application.StateUseCades;

namespace Workflow.Web.Api.Endpoints
{
    public static class StateEndPoints
    {
        public static void MapStateEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/state")
                .WithTags("State Entity");

            group.MapGet("/", async (GetAllState useCase) =>
            {
                try
                {
                    var states = await useCase.ExecuteAsync();
                    return Results.Ok(states.Select(s => new StateDto
                    {
                        Code = s.Code,
                        Description = s.Description,
                    }));
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex.Message);
                }
            });
        }
    }
}
