using Domain.Models;

namespace Application.Abstractions;

public interface ITodoRepository
{
    Task<Todo> GetTodoAsync(string id, CancellationToken cancellationToken);

    Task<IEnumerable<Todo>> GetTodosAsync(string? category, CancellationToken cancellationToken);
}