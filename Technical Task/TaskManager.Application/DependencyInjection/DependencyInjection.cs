using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Features.Projects.Interfaces;
using TaskManager.Application.Features.Projects.Services;
using TaskManager.Application.Features.Tasks.Interfaces;
using TaskManager.Application.Features.Tasks.Services;

namespace TaskManager.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskService, TaskService>();

        return services;
    }

}