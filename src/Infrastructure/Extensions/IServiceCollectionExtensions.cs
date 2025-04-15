
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {

        //services.AddDbContext(configuration);
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient<ICustomerRepository, CustomerRepository>();
    }
}
