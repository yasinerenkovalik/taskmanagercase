using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskManager.Persistance.Context;

public class TaskManagerContextFactory 
    : IDesignTimeDbContextFactory<TaskManagerContext>
{
    public TaskManagerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TaskManagerContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=taskmanager_db;Username=taskmanager_user;Password=taskmanager_pass");

        return new TaskManagerContext(optionsBuilder.Options);
    }
}