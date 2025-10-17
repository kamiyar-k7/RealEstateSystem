
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
            options.UseSqlServer(configuration.GetConnectionString("RealStateDbConnectionString")));



        return services;
    }

}
