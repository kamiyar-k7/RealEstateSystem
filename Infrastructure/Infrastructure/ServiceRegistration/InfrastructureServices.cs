
using Application.DataBaseContextInterface;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceRegistration;

public static class InfrastructureServices
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<RealEstateDataBaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("RealEstateDbConnectionString")));


        services.AddScoped<IRealEstateDataBaseContext>(provider =>
            provider.GetRequiredService<RealEstateDataBaseContext>());

        return services;
    }

}
