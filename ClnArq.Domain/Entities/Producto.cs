﻿namespace ClnArq.Domain.Entities;

public class Producto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public ICollection<DetalleVenta>? DetallesVenta { get; set; } = new List<DetalleVenta>();
}
