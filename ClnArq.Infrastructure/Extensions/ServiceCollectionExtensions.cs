using ClnArq.Domain.Repositories;
using ClnArq.Infrastructure.Persistence;
using ClnArq.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClnArq.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1) Registrar DbContext
        services.AddDbContext<ClnArqDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(typeof(ClnArqDbContext).Assembly.FullName)
            )
        );

      
        services.AddScoped<IStoreRepository, StoreRepository>();

        return services;
    }
}
