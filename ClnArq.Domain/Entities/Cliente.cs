namespace ClnArq.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Telefono { get; set; }

    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
