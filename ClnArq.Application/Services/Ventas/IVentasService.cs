using ClnArq.Application.Dtos;

namespace ClnArq.Application.Services.Ventas;

public interface IVentasService
{
    Task<IEnumerable<VentaDto>> GetAllVentasAsync();
    Task<VentaDto?> GetVentaByIdAsync(Guid id);
    Task<bool> CreateVentaAsync(ProductoDto producto);
    Task<bool> UpdateVentaAsync(ProductoDto producto);
    Task<bool> DeleteVentaAsync(Guid id);
}
