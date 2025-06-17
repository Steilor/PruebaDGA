namespace ClnArq.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Telefono { get; set; }

    public string Direccion { get; set; } = string.Empty;

    public DateTime Creado { get; set; } = DateTime.UtcNow;

    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
