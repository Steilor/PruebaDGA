using ClnArq.Application.Dtos;
using ClnArq.Domain.Entities;

namespace ClnArq.Application.Services;

public interface IStoreService
{
    Task<IEnumerable<Producto>> GetAllProductosAsync();
    Task<Producto?> GetProductoByIdAsync(Guid id);
    Task<bool> CreateProductoAsync(ProductoDto producto);
    Task<bool> UpdateProductoAsync(ProductoDto producto);
    Task<bool> DeleteProductoAsync(Guid id);
}
