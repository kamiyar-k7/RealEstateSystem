
using Application.Services.BlogServices;
using Application.Services.CityServices;
using Application.Services.PropertyServices;
using Application.Services.ProvinceServices;
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


        services.AddScoped<IPropertyServices, PropertyService>();
        services.AddScoped<ICityServices, CityServices>();
        services.AddScoped<IProvinceServices, ProvinceServices>();


        services.AddScoped<IBlogServices , BlogServices>();


        return services;

    }

}
