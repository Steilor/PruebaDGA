namespace ClnArq.Application.Dtos.Clientes;

public class ClientesDtoGetAll : ClientesDtoBase
{
    public Guid Id { get; set; }
    public DateTime Creado { get; set; } = DateTime.UtcNow;
}
