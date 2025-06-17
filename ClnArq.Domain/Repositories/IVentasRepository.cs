using ClnArq.Domain.Entities;

namespace ClnArq.Domain.Repositories;

public interface IVentasRepository
{
    Task<IEnumerable<Venta>> GetAllAsync();
    Task<Venta?> GetByIdAsync(int id);
    Task AddAsync(Venta venta);
    void Update(Venta venta);
    void Delete(Venta venta);
    Task<bool> ExistsAsync(int id);
    Task SaveChangesAsync();
}
