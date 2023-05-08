using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myTechnicCase.Application.Interfaces.Repositories;
using myTechnicCase.Persistence.DataContext;
using myTechnicCase.Persistence.Repositories;

namespace myTechnicCase.Persistence;

public static class ServiceRegistrations
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DBConStr");
        services.AddDbContext<MyTechnicDbContext>(options =>
            options.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            })
        );

        services.AddScoped<IPersonnelRepository, PersonnelRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IShiftRepository, ShiftRepository>();
    }
}