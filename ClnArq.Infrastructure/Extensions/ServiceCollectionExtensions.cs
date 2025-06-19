using ClnArq.Domain.Repositories;
using ClnArq.Infrastructure.Identity;
using ClnArq.Infrastructure.Persistence;
using ClnArq.Infrastructure.Repositories;
using ClnArq.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClnArq.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ClnArqDbContext>(options =>
            options.UseSqlServer(connectionString)              
        );

        services.AddIdentityApiEndpoints<ApplicationUser>()
               .AddEntityFrameworkStores<ClnArqDbContext>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IVentasRepository, VentasRepository>();
        services.AddScoped<IClientesRepository, ClientesRepository>();
        services.AddScoped<IClnArqSeeder, ClnArqSeeder>();

    }
}
