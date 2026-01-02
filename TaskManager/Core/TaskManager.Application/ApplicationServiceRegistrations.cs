using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TaskManager.Application;

public static class ServiceRegistrations
{
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(assembly));

        // AutoMapper
        services.AddAutoMapper(assembly);

        // FluentValidation (tüm validator'lar otomatik)
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}