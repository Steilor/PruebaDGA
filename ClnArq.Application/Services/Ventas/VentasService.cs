using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Domain.Entities;
using ClnArq.Domain.Exceptions;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services.Ventas;

internal class VentasService(IVentasRepository ventasRepository,
    IMapper mapper) : IVentasService
{
    public async Task<bool> CreateVentaAsync(VentaDto ventaDto)
    {
        var venta = mapper.Map<Venta>(ventaDto);
        
        if(venta == null)
            throw new NotFoundException();

        await ventasRepository.AddAsync(venta);
        await ventasRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteVentaAsync(int id)
    {
        var venta = await ventasRepository.GetByIdAsync(id);
        if(venta == null)
            throw new NotFoundException();

         ventasRepository.Delete(venta);
        await ventasRepository.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<VentaDto>> GetAllVentasAsync()
    {
        var ventas = await ventasRepository.GetAllAsync();

        if (ventas == null || !ventas.Any())
            throw new NotFoundException();

        var ventasDto = mapper.Map<IEnumerable<VentaDto>>(ventas);

        return ventasDto;
    }

    public async Task<VentaDto?> GetVentaByIdAsync(int id)
    {
        var venta = await ventasRepository.GetByIdAsync(id);

        if (venta == null)
            throw new NotFoundException();

        var ventaDto = mapper.Map<VentaDto>(venta);

        return ventaDto;
    }

    public async Task<bool> UpdateVentaAsync(VentaDto ventaDto)
    {
        var venta = await ventasRepository.GetByIdAsync(ventaDto.Id);
        if (venta == null)
            throw new NotFoundException();


        venta.Cantidad = ventaDto.Cantidad;
        venta.Fecha = ventaDto.Date;
        venta.Total = ventaDto.TotalAmount;
        venta.ClienteId = ventaDto.ClienteId;
        venta.ProductoId = ventaDto.ProductoId;

        venta.ClienteNombre =ventaDto.NombreCliente;
        venta.ProductoNombre = ventaDto.NombreProducto;
        venta.ProductoPrecioUnitario = ventaDto.PrecioUnico;

        ventasRepository.Update(venta);
        await ventasRepository.SaveChangesAsync();

        return true;
    }

}
