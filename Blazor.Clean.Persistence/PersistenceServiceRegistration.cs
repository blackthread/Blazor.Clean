using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Persistence.DatabaseContext;
using Blazor.Clean.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Clean.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BlazorCleanDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<IToDoItemRepository, ToDoItemRepository>();

        return services;
    }
}
