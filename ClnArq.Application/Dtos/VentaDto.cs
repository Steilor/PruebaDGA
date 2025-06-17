namespace ClnArq.Application.Dtos;

public class VentaDto
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid ProductoId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }

  
}
