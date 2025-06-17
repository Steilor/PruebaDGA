using ClnArq.Application.Services.Product;
using Microsoft.Extensions.DependencyInjection;

namespace ClnArq.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
     
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

        services.AddScoped<IStoreService, StoreService>();

        return services;
    }
}
