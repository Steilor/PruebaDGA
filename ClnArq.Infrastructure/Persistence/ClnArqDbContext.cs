using ClnArq.Application.Services;
using ClnArq.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClnArq.Infrastructure.Persistence;

public class ClnArqDbContext : DbContext, IStoreService
{
    public ClnArqDbContext(DbContextOptions<ClnArqDbContext> options)
       : base(options)
    {
    }


    public DbSet<Producto> Productos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleVenta> DetallesVenta { get; set; }
    public DbSet<User> User { get; set; }

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

        // Configuración para Usuario
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.ContrasenaHash)
                .IsRequired()
                .HasMaxLength(255); 

            entity.Property(u => u.Rol)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasIndex(u => u.NombreUsuario)
                .IsUnique();

            entity.HasIndex(u => u.Email)
                .IsUnique();
        });



    }

}
