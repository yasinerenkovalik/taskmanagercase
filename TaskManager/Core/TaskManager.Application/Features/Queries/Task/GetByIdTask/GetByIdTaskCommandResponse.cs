namespace TaskManager.Application.Features.Queries.Task.GetByIdTask;

public class GetByIdTaskCommandResponse
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public TaskStatus Status { get; set; } 
    public bool IsDeleted { get; set; } = false;
    public Guid Id { get; set; }
}