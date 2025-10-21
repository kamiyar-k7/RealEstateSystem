
using Application.Services.RoleServices;
using Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

public static class ApplicationConfiguration
{

    public static IServiceCollection AddApplicationServcies(this IServiceCollection services)
    {

        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IRoleServices, RoleServices>();



        return services;

    }

}
