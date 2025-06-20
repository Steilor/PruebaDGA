namespace ClnArq.Application.Dtos.Ventas;

public class VentasDtoUpdate : VentasDtoBase
{
    public int Id { get; set; }
    public int PrecioUnico { get; set; }
    public string NombreProducto { get; set; } = string.Empty;

}
