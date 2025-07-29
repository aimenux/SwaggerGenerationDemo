using Domain.Models;

namespace Application.Services;

public interface ITodoService
{
    Task<Todo> GetTodoAsync(string id, CancellationToken cancellationToken);

    Task<IEnumerable<Todo>> GetTodosAsync(string? category, CancellationToken cancellationToken);
}