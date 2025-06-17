namespace ClnArq.Application.Dtos;

public class ClienteDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;

    public DateTime Creado { get; set; } = DateTime.UtcNow;
    public string? Telefono { get; set; }
}
