namespace ClnArq.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ContrasenaHash { get; set; } = string.Empty;
    public string Rol { get; set; } 
}
