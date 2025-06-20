using ClnArq.Application.Dtos;
using ClnArq.Application.Dtos.Clientes;

namespace ClnArq.Application.Services.Clientes;

public interface IClientesService 
{
    Task<IEnumerable<ClientesDtoGetAll>> GetAllClientesAsync();
    Task<ClientesDtoGetAll?> GetClienteByIdAsync(Guid id);
    Task<bool> CreateClienteAsync(ClientesDtoAdd clienteDto);
    Task<bool> UpdateClienteAsync(ClientesDtoUpdate clienteDto);
    Task<ClientesDtoRemove> DeleteClienteAsync(Guid id);
}
