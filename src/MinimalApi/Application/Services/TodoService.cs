using Application.Abstractions;
using Domain.Models;

namespace Application.Services;

public sealed class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Todo> GetTodoAsync(string id, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodoAsync(id, cancellationToken);
        return todo;
    }

    public async Task<IEnumerable<Todo>> GetTodosAsync(string? category, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetTodosAsync(category, cancellationToken);
        return todos;
    }
}