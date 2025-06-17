using ClnArq.Application.Services;
using ClnArq.Domain.Entities;
using ClnArq.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClnArq.Infrastructure.Persistence;

public class ClnArqDbContext(DbContextOptions<ClnArqDbContext> options) 
    : IdentityDbContext<ApplicationUser>(options)
{

    internal DbSet<Producto> Productos { get; set; }
    internal DbSet<Cliente> Clientes { get; set; }
    internal DbSet<Venta> Ventas { get; set; }
    internal DbSet<DetalleVenta> DetallesVenta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Descripcion)
                .HasMaxLength(500);

            entity.Property(p => p.Precio)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(p => p.Stock)
                .IsRequired();

            entity.HasIndex(p => p.Nombre)
                .IsUnique();
        });

      
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Telefono)
                .HasMaxLength(20);

            entity.HasIndex(c => c.Email)
                .IsUnique();
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.Property(v => v.Fecha)
                .IsRequired();

            entity.Property(v => v.Total)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

           
            entity.HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        });

       
        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.Property(d => d.Cantidad)
                .IsRequired();

            entity.Property(d => d.PrecioUnitario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

          
            entity.HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Cascade);

          
            entity.HasOne(d => d.Producto)
                .WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);


        });

    



    }

}
