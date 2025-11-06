
using Application.Services.BlogServices;
using Application.Services.CityServices;
using Application.Services.PropertyServices;
using Application.Services.ProvinceServices;
using Application.Services.RoleServices;
using Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application.Configuration;

public static class ApplicationConfiguration
{

    public static IServiceCollection AddApplicationServcies(this IServiceCollection services )
    {


        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        //identity
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IRoleServices, RoleServices>();

       
        //property
        services.AddScoped<IPropertyTypeServices ,  PropertyTypeServices>();
        services.AddScoped<ICityServices, CityServices>();
        services.AddScoped<IProvinceServices, ProvinceServices>();



        //blog
        services.AddScoped<IBlogServices , BlogServices>();
        services.AddScoped<IBlogCategoryServices, BlogCategoryServices>();


        return services;

    }

}
