using ClnArq.Application.Dtos;

namespace ClnArq.Application.Services.Clientes;

public interface IClientesService 
{
    Task<IEnumerable<ClienteDto>> GetAllClientesAsync();
    Task<ClienteDto?> GetClienteByIdAsync(Guid id);
    Task<bool> CreateClienteAsync(ClienteDto clienteDto);
    Task<bool> UpdateClienteAsync(ClienteDto clienteDto);
    Task<bool> DeleteClienteAsync(Guid id);
}
