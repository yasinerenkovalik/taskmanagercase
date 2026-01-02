using FluentValidation;
using HappyDay.Persistance.Security;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.Application;

public static class ApplicationLayerService
{
    public static IServiceCollection AddAplicationLayerServices(this IServiceCollection services)
    {
        var assembly = typeof(ApplicationLayerService).Assembly;

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(assembly));

        services.AddAutoMapper(typeof(ApplicationLayerService));

        services.AddValidatorsFromAssembly(assembly);
        services.AddScoped<JwtService>();

        return services;
    }
}
