namespace ClnArq.Application.Dtos.Productos;

public class ProductosDtoBase
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}
