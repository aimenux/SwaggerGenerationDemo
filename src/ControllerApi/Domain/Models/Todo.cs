namespace Domain.Models;

public sealed record Todo
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public string? Category { get; init; }
    public bool IsCompleted { get; init; }
    public DateTime CreationDate { get; init; }
}