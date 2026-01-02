

namespace TaskManager.Domain.Entities;

public class TaskItem:BaseEntity
{

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public TaskStatus Status { get; set; } = TaskStatus.Todo;
    public bool IsDeleted { get; set; } = false;
}
public enum TaskStatus
{
    Todo = 0,
    InProgress = 1,
    Done = 2
}