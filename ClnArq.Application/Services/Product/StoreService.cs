using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Domain.Entities;
using ClnArq.Domain.Exceptions;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services.Product;

internal class StoreService(IStoreRepository _storeRepository,
    IMapper mapper) : IStoreService
{

    public async Task<IEnumerable<ProductoDto>> GetAllProductosAsync()
    {
        var productos = await _storeRepository.GetAllAsync();
        var productosDto = mapper.Map<IEnumerable<ProductoDto>>(productos);

        return productosDto;
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
            throw new NotFoundException();

        _storeRepository.Delete(producto);
        await _storeRepository.SaveChangesAsync();
        return true;
    }
}
