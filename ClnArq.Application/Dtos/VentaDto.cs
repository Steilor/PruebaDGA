namespace ClnArq.Application.Dtos;

public class VentaDto
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public int PrecioUnico { get; set; }

    public Guid ClienteId { get; set; }
    public string NombreCliente { get; set; } = string.Empty;

    public Guid ProductoId { get; set; }
    public string NombreProducto { get; set; } = string.Empty;

    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }


}
