using ClnArq.Domain.Entities;
using ClnArq.Domain.Repositories;
using ClnArq.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClnArq.Infrastructure.Repositories;

public class ClientesRepository(ClnArqDbContext _context) : IClientesRepository
{
    public async Task AddAsync(Cliente cliente)
    {
        await _context.AddAsync(cliente);
    }

    public void Delete(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Clientes.AnyAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
    }
}
