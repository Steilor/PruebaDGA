using ClnArq.Application.Services.Clientes;
using ClnArq.Application.Services.Product;
using ClnArq.Application.Services.Ventas;
using Microsoft.Extensions.DependencyInjection;

namespace ClnArq.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
     
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IVentasService, VentasService>();
        services.AddScoped<IClientesService, ClientesService>();

        return services;
    }
}
