using ClnArq.Domain.Entities;

namespace ClnArq.Application.Services;

public interface IStoreService
{
    Task<IEnumerable<Producto>> GetAllProductosAsync();
    Task<Producto?> GetProductoByIdAsync(Guid id);
    Task<Producto> CreateProductoAsync(Producto producto);
    Task<bool> UpdateProductoAsync(Producto producto);
    Task<bool> DeleteProductoAsync(Guid id);
}
