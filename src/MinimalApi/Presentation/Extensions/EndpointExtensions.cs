using Presentation.Endpoints;

namespace Presentation.Extensions;

public static class EndpointExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapTodosEndpoints();
    }
}