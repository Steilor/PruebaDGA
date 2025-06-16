namespace ClnArq.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }

    public ICollection<Ventas> Ventas { get; set; } = new List<Ventas>();
}
