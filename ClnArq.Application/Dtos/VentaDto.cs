namespace ClnArq.Application.Dtos;

public class VentaDto
{
    public int Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid ProductoId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }

  
}
