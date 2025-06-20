using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Application.Dtos.Productos;
using ClnArq.Domain.Entities;
using ClnArq.Domain.Exceptions;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services.Product;

internal class ProductService(IProductRepository _storeRepository,
    IMapper mapper) : IProductService
{

    public async Task<IEnumerable<ProductosDtoGetAll>> GetAllProductosAsync()
    {
        var productos = await _storeRepository.GetAllAsync();

        return mapper.Map<IEnumerable<ProductosDtoGetAll>>(productos);
    }

    public async Task<ProductosDtoGetAll?> GetProductoByIdAsync(Guid id)
    {
        var producto = await _storeRepository.GetByIdAsync(id);
        if (producto == null) 
            throw new NotFoundException($"Producto con Id {id} no encontrado.");

        return mapper.Map<ProductosDtoGetAll>(producto);
    }

    public async Task<bool> CreateProductoAsync(ProductosDtoAdd productoDto)
    {
        var producto = mapper.Map<Producto>(productoDto);
        await _storeRepository.AddAsync(producto);
        await _storeRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateProductoAsync(ProductosDtoUpdate productoDto)
    {
        var existing = await _storeRepository.GetByIdAsync(productoDto.Id);
        if (existing == null)
            throw new NotFoundException($"Producto con Id {productoDto.Id} no encontrado.");

        existing.Nombre = productoDto.Nombre;
        existing.Descripcion = productoDto.Descripcion;
        existing.Precio = productoDto.Precio;
        existing.Stock = productoDto.Stock;

        _storeRepository.Update(existing);
        await _storeRepository.SaveChangesAsync();
        return true;
    }

    public async Task<ProductosDtoRemove> DeleteProductoAsync(Guid id)
    {
        var producto = await _storeRepository.GetByIdAsync(id);
        if (producto == null)
            throw new NotFoundException($"Producto con Id {id} no encontrado.");

        _storeRepository.Delete(producto);
        await _storeRepository.SaveChangesAsync();

        return new ProductosDtoRemove
        {
            ProductoId = id,
            Eliminado = true
        };
    }
}
