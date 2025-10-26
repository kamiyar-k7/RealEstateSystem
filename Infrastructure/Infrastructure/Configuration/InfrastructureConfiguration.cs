using Domain.IRepository.BlogIRepositories;
using Domain.IRepository.IdentityIRepositories;
using Domain.IRepository.LocationIRepositories;
using Domain.IRepository.PropertyIRepsitories;
using Infrastructure.AppDbContext;
using Infrastructure.Repositories.BlogRepositories;
using Infrastructure.Repositories.IdentityRepositories;
using Infrastructure.Repositories.LocationRepositories;
using Infrastructure.Repositories.PropertyRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class InfrastructureConfiguration
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<RealEstateDataBaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("RealEstateDbConnectionString")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        //services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<ICityRepository , CityRepository>();


        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();


        return services;
    }

}
