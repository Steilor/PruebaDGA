namespace ClnArq.Application.Dtos.Ventas;

public class VentasDtoAdd : VentasDtoBase
{

    public Guid ClienteId { get; set; }

    public Guid ProductoId { get; set; }

}
