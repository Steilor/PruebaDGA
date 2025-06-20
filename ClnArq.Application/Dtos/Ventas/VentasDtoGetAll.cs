namespace ClnArq.Application.Dtos.Ventas;

public class VentasDtoGetAll : VentasDtoBase
{
    public int Id { get; set; }
    public int PrecioUnico { get; set; }

    public Guid ClienteId { get; set; }
    public string NombreCliente { get; set; } = string.Empty;

    public Guid ProductoId { get; set; }
    public string NombreProducto { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }
}
