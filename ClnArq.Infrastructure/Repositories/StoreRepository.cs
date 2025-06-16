using ClnArq.Domain.Entities;
using ClnArq.Domain.Repositories;
using ClnArq.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClnArq.Infrastructure.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly ClnArqDbContext _context;

    public StoreRepository(ClnArqDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task AddAsync(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
    }

    public void Update(Producto producto)
    {
        _context.Productos.Update(producto);
    }

    public void Delete(Producto producto)
    {
        _context.Productos.Remove(producto);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Productos.AnyAsync(p => p.Id = id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
