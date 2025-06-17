using ClnArq.Application.Dtos;
using ClnArq.Domain.Entities;

namespace ClnArq.Application.Services.Product;

public interface IProductService
{
    Task<IEnumerable<ProductoDto>> GetAllProductosAsync();
    Task<ProductoDto?> GetProductoByIdAsync(Guid id);
    Task<bool> CreateProductoAsync(ProductoDto producto);
    Task<bool> UpdateProductoAsync(ProductoDto producto);
    Task<bool> DeleteProductoAsync(Guid id);
}
