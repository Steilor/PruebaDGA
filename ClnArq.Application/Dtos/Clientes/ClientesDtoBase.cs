﻿namespace ClnArq.Application.Dtos.Clientes;

public class ClientesDtoBase
{
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string? Telefono { get; set; }
}
