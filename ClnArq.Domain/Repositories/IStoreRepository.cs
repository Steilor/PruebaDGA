using ClnArq.Domain.Entities;

namespace ClnArq.Domain.Repositories;

public interface IStoreRepository
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task AddAsync(Producto producto);
    void Update(Producto producto);
    void Delete(Producto producto);
    Task<bool> ExistsAsync(int id);
    Task SaveChangesAsync();
}
