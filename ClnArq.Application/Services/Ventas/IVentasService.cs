using ClnArq.Application.Dtos;
using ClnArq.Application.Dtos.Ventas;

namespace ClnArq.Application.Services.Ventas;

public interface IVentasService
{
    Task<IEnumerable<VentasDtoGetAll>> GetAllVentasAsync();
    Task<VentasDtoGetAll?> GetVentaByIdAsync(int id);
    Task<bool> CreateVentaAsync(VentasDtoAdd ventasDtoAdd);
    Task<bool> UpdateVentaAsync(VentasDtoUpdate ventasDtoUpdate);
    Task<VentasDtoRemove> DeleteVentaAsync(int id);
}
