using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Domain.Entities;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services;

internal class StoreService(IStoreRepository storeRepository,
    IMapper mapper) : IStoreService
{
    private readonly IStoreRepository _storeRepository = storeRepository;

    public async Task<IEnumerable<ProductoDto>> GetAllProductosAsync()
    {
        var productos = await _storeRepository.GetAllAsync();
        var productosDto = mapper.Map<ProductoDto>(productos);

        return (IEnumerable<ProductoDto>)productosDto;
    }

    public async Task<ProductoDto?> GetProductoByIdAsync(Guid id)
    {
        var producto = await _storeRepository.GetByIdAsync(id);
        var productoDto = mapper.Map<ProductoDto>(producto);
        return productoDto;
    }

    public async Task<bool> CreateProductoAsync(ProductoDto productoDto)
    {
        var producto = mapper.Map<Producto>(productoDto);

        await _storeRepository.AddAsync(producto);
        await _storeRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateProductoAsync(ProductoDto productoDto)
    {
        var exists = await _storeRepository.ExistsAsync(productoDto.Id);
        if (!exists)
            return false;
        var producto = mapper.Map<Producto>(productoDto);

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
