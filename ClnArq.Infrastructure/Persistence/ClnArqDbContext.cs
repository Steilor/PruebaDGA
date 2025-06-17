using ClnArq.Domain.Entities;
using ClnArq.Infrastructure.Identity;
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


        
        modelBuilder.Entity<Venta>(eb =>
        {
            eb.HasKey(v => v.Id);
            eb.Property(v => v.Total)
              .HasColumnType("decimal(18,2)")
              .IsRequired();
            eb.Property(v => v.Fecha)
              .HasDefaultValueSql("getutcdate()");
            eb.HasOne<Cliente>()
              .WithMany(c => c.Ventas)
              .HasForeignKey(v => v.ClienteId)
              .OnDelete(DeleteBehavior.Restrict);
            eb.HasMany(v => v.DetallesVenta)
              .WithOne(dv => dv.Venta)
              .HasForeignKey(dv => dv.VentaId)
              .OnDelete(DeleteBehavior.Cascade);
        });

       
        modelBuilder.Entity<Producto>(eb =>
        {
            eb.HasKey(p => p.Id);
            eb.Property(p => p.Nombre)
              .IsRequired()
              .HasMaxLength(200);
            eb.Property(p => p.Precio)
              .HasColumnType("decimal(18,2)")
              .IsRequired();
            eb.HasMany(p => p.DetallesVenta)
              .WithOne(dv => dv.Producto)
              .HasForeignKey(dv => dv.ProductoId)
              .OnDelete(DeleteBehavior.Restrict);
        });

      
        modelBuilder.Entity<DetalleVenta>(eb =>
        {
            eb.HasKey(dv => dv.Id);
            eb.Property(dv => dv.PrecioUnitario)
              .HasColumnType("decimal(18,2)")
              .IsRequired();
            eb.Property(dv => dv.Cantidad)
              .IsRequired();
        });

     
        modelBuilder.Entity<Cliente>(eb =>
        {
            eb.HasKey(c => c.Id);
            eb.Property(c => c.Nombre)
              .IsRequired()
              .HasMaxLength(150);
            eb.Property(c => c.Email)
              .IsRequired()
              .HasMaxLength(200);
            eb.Property(c => c.Telefono)
               .HasMaxLength(50);
            eb.Property(c => c.Direccion)
              .IsRequired()
              .HasMaxLength(300);
            eb.Property(c => c.Creado)
              .HasDefaultValueSql("getutcdate()");
        });


    }

}
