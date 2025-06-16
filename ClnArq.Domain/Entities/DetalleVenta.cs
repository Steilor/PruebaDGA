namespace ClnArq.Domain.Entities;

public class DetalleVenta
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

  
    public int VentaId { get; set; }
    public Venta Venta { get; set; } = null!;

 
    public Guid ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;
}
