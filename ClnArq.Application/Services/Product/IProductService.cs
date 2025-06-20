using ClnArq.Application.Dtos;
using ClnArq.Application.Dtos.Productos;
using ClnArq.Domain.Entities;

namespace ClnArq.Application.Services.Product;

public interface IProductService
{
    Task<IEnumerable<ProductosDtoGetAll>> GetAllProductosAsync();
    Task<ProductosDtoGetAll?> GetProductoByIdAsync(Guid id);
    Task<bool> CreateProductoAsync(ProductosDtoAdd producto);
    Task<bool> UpdateProductoAsync(ProductosDtoUpdate producto);
    Task<ProductosDtoRemove> DeleteProductoAsync(Guid id);
}
