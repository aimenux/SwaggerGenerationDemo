using Application.Abstractions;
using Domain.Models;

namespace Infrastructure.Repositories;

public sealed class TodoRepository : ITodoRepository
{
    private static readonly TimeSpan Delay = TimeSpan.FromMilliseconds(50);

    public async Task<Todo> GetTodoAsync(string id, CancellationToken cancellationToken)
    {
        await Task.Delay(Delay, cancellationToken);
        var todo = GetTodo(id, $"category-{RandomNumber()}");
        return todo;
    }

    public async Task<IEnumerable<Todo>> GetTodosAsync(string? category, CancellationToken cancellationToken)
    {
        await Task.Delay(Delay, cancellationToken);
        var todos = Enumerable.Range(1, RandomNumber())
            .Select(x => GetTodo($"{x}", category))
            .ToList();
        return todos;
    }

    private static Todo GetTodo(string id, string? category)
    {
        return new Todo
        {
            Id = id,
            Title = Guid.NewGuid().ToString("N"),
            Category = category,
            IsCompleted = RandomNumber() % 2 == 0,
            CreationDate = DateTime.Now.AddDays(-RandomNumber())
        };
    }

    private static int RandomNumber(int min = 1, int max = 100)
    {
        return Random.Shared.Next(min, max);
    }
}