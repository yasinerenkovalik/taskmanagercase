

using TaskManager.Application.Interface.Repository;
using TaskManager.Domain.Entities;
using TaskManager.Persistance.Context;
using Task = TaskManager.Domain.Entities.TaskItem;

namespace TaskManager.Persistance.Repositories;

public class TaskRepository:GenericRepository<TaskItem>,ITaskItemRepository
{
    public TaskRepository(TaskManagerContext appContext) : base(appContext)
    {
    }
}