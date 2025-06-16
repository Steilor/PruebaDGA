using ClnArq.Domain.Entities;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services;

internal class StoreService(IStoreRepository storeRepository) : IStoreService
{
    private readonly IStoreRepository _storeRepository = storeRepository;

    public async Task<IEnumerable<Producto>> GetAllProductosAsync()
    {
        return await _storeRepository.GetAllAsync();
    }

    public async Task<Producto?> GetProductoByIdAsync(Guid id)
    {
        return await _storeRepository.GetByIdAsync(id);
    }

    public async Task<Producto> CreateProductoAsync(Producto producto)
    {
        await _storeRepository.AddAsync(producto);
        await _storeRepository.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> UpdateProductoAsync(Producto producto)
    {
        var exists = await _storeRepository.ExistsAsync(producto.Id);
        if (!exists)
            return false;

        _storeRepository.Update(producto);
        await _storeRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProductoAsync(Guid id)
    {
        var producto = await _storeRepository.GetByIdAsync(id);
        if (producto == null)
            return false;

        _storeRepository.Delete(producto);
        await _storeRepository.SaveChangesAsync();
        return true;
    }
}
