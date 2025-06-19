namespace ClnArq.Domain.Entities;

public class Venta
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }

    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }  

    public Guid ProductoId { get; set; }
    public Producto Producto { get; set; }

 
    public string ClienteNombre { get; set; } = string.Empty;
    public string ProductoNombre { get; set; } = string.Empty;
    public decimal ProductoPrecioUnitario { get; set; }

    public ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();
}
