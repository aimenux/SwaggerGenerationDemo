using Application.Services;
using Asp.Versioning;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Endpoints;

public static class TodosEndpoints
{
    public static IEndpointRouteBuilder MapTodosEndpoints(this IEndpointRouteBuilder app)
    {        
        var versions = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1.0))
            .HasApiVersion(new ApiVersion(2.0))
            .HasDeprecatedApiVersion(new ApiVersion(1.0))
            .ReportApiVersions()
            .Build();
        
        var group = app
            .MapGroup("api/v{version:apiVersion}/todos")
            .WithApiVersionSet(versions)
            .WithName("TodosEndpoints")
            .WithTags("Todos");

        group
            .MapGet("",
                async (ITodoService todoService, [FromQuery] string? category, CancellationToken cancellationToken) =>
                {
                    var todos = await todoService.GetTodosAsync(category, cancellationToken);
                    return TypedResults.Ok(todos);
                })
            .WithName("GetTodos")
            .WithSummary("Retrieves a list of todos")
            .WithDescription("Gets all todos, optionally filtered by category")
            .Produces<IEnumerable<Todo>>(contentType: "application/json")
            .MapToApiVersion(1.0);

        group
            .MapGet("{id}",
                async (ITodoService todoService, string id, CancellationToken cancellationToken) =>
                {
                    var todo = await todoService.GetTodoAsync(id, cancellationToken);
                    return TypedResults.Ok(todo);
                })
            .WithName("GetTodo")
            .WithSummary("Retrieves a todo")
            .WithDescription("Get todo by id")
            .Produces<Todo>(contentType: "application/json")
            .MapToApiVersion(2.0);

        return app;
    }
}