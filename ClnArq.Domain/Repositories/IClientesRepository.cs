using ClnArq.Domain.Entities;

namespace ClnArq.Domain.Repositories;

public interface IClientesRepository
{
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(Guid id);
    Task AddAsync(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(Cliente cliente);
    Task<bool> ExistsAsync(Guid id);
    Task SaveChangesAsync();
}
