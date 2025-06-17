namespace ClnArq.Domain.Entities;

public class Venta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }

    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
}
