using ClnArq.Application.Dtos;

namespace ClnArq.Application.Services.Ventas;

public interface IVentasService
{
    Task<IEnumerable<VentaDto>> GetAllVentasAsync();
    Task<VentaDto?> GetVentaByIdAsync(int id);
    Task<bool> CreateVentaAsync(VentaDto ventaDto);
    Task<bool> UpdateVentaAsync(VentaDto ventaDto);
    Task<bool> DeleteVentaAsync(int id);
}
