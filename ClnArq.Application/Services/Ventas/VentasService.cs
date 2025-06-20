using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Application.Dtos.Ventas;
using ClnArq.Domain.Entities;
using ClnArq.Domain.Exceptions;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services.Ventas;

internal class VentasService(IVentasRepository _ventasRepository,
    IMapper _mapper,
     IClientesRepository _clientesRepository,
     IProductRepository _productosRepository) : IVentasService
{
    public async Task<bool> CreateVentaAsync(VentasDtoAdd dto)
    {
        var venta = _mapper.Map<Venta>(dto);

        var cliente = await _clientesRepository.GetByIdAsync(dto.ClienteId)
                     ?? throw new NotFoundException($"Cliente {dto.ClienteId} no encontrado");
        var producto = await _productosRepository.GetByIdAsync(dto.ProductoId)
                      ?? throw new NotFoundException($"Producto {dto.ProductoId} no encontrado");

        venta.ClienteNombre = cliente.Nombre;
        venta.ProductoNombre = producto.Nombre;
        venta.ProductoPrecioUnitario = producto.Precio;

        venta.Total = venta.ProductoPrecioUnitario * venta.Cantidad;

        await _ventasRepository.AddAsync(venta);
        await _ventasRepository.SaveChangesAsync();
        return true;
    }

    public async Task<VentasDtoRemove> DeleteVentaAsync(int id)
    {
        var venta = await _ventasRepository.GetByIdAsync(id)
                    ?? throw new NotFoundException($"Venta {id} no encontrada");

        _ventasRepository.Delete(venta);
        await _ventasRepository.SaveChangesAsync();

        return new VentasDtoRemove { VentaId = id, Eliminado = true };
    }

    public async Task<IEnumerable<VentasDtoGetAll>> GetAllVentasAsync()
    {
        var ventas = await _ventasRepository.GetAllAsync();
        if (ventas == null || !ventas.Any())
            throw new NotFoundException("No hay ventas registradas");

        return _mapper.Map<IEnumerable<VentasDtoGetAll>>(ventas);
    }

    public async Task<VentasDtoGetAll?> GetVentaByIdAsync(int id)
    {
        var venta = await _ventasRepository.GetByIdAsync(id)
                     ?? throw new NotFoundException($"Venta {id} no encontrada");

        return _mapper.Map<VentasDtoGetAll>(venta);
    }

    public async Task<bool> UpdateVentaAsync(VentasDtoUpdate dto)
    {
        var venta = await _ventasRepository.GetByIdAsync(dto.Id)
                   ?? throw new NotFoundException($"Venta {dto.Id} no encontrada");

        venta.Cantidad = dto.Cantidad;
        venta.Fecha = dto.Date;
        venta.ProductoPrecioUnitario = dto.PrecioUnico;
        venta.ProductoNombre = dto.NombreProducto;

        venta.Total = venta.ProductoPrecioUnitario * venta.Cantidad;

        _ventasRepository.Update(venta);
        await _ventasRepository.SaveChangesAsync();
        return true;
    }

}
