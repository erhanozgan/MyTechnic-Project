using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myTechnicCase.Application.Concrete;
using myTechnicCase.Application.Interfaces.Services;

namespace myTechnicCase.Application;

public static class ServiceRegistrations
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPersonnelService, PersonnelService>();
        services.AddScoped<IShiftService, ShiftService>();
        services.AddScoped<ITeamService, TeamService>();
    }
}