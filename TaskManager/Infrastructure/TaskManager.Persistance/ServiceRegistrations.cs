


using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interface.Repository;
using TaskManager.Domain.Entities;
using TaskManager.Persistance.Repositories;

namespace TaskManager.Infrastructure.Persistence;

public static class ServiceRegistrations
{
    public static IServiceCollection AddPersistanceLayerServices(this IServiceCollection services)
    {
        services.AddScoped<ITaskItemRepository, TaskRepository>();
   
           
        return services;

        
    }
}