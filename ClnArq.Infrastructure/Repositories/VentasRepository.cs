using ClnArq.Domain.Entities;
using ClnArq.Domain.Repositories;
using ClnArq.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClnArq.Infrastructure.Repositories;

public class VentasRepository(ClnArqDbContext _context) : IVentasRepository
{
    public async Task AddAsync(Venta venta)
    {
        await _context.AddAsync(venta);
    }

    public void Delete(Venta venta)
    {
        _context.Ventas.Remove(venta);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Ventas.AnyAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Ventas
           .Include(v => v.Cliente)
           .Include(v => v.Producto)
           .ToListAsync();
    }

    public async Task<Venta?> GetByIdAsync(int id)
    {
        return await _context.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Producto)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Venta venta)
    {
        _context.Ventas.Update(venta);
    }
}
