using Application.Services;
using Asp.Versioning;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[ApiVersion(1.0, Deprecated = true)]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/todos")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [Tags("Todos")]
    [EndpointName("GetTodos")]
    [EndpointSummary("Retrieves a list of todos")]
    [EndpointDescription("Gets all todos, optionally filtered by category")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Todo>), StatusCodes.Status200OK)]
    [HttpGet("")]
    public async Task<IEnumerable<Todo>> GetTodosAsync([FromQuery] string? category, CancellationToken cancellationToken)
    {
        var todos = await _todoService.GetTodosAsync(category, cancellationToken);
        return todos;
    }

    [Tags("Todos")]
    [EndpointName("GetTodo")]
    [EndpointSummary("Retrieves a todo")]
    [EndpointDescription("Get todo by id")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [MapToApiVersion(2.0)]
    [HttpGet("{id}")]
    public async Task<Todo> GetTodoAsync([FromRoute] string id, CancellationToken cancellationToken)
    {
        var todo = await _todoService.GetTodoAsync(id, cancellationToken);
        return todo;
    }
}