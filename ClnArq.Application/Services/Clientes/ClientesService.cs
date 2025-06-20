using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Application.Dtos.Clientes;
using ClnArq.Domain.Entities;
using ClnArq.Domain.Exceptions;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services.Clientes;

internal class ClientesService(IClientesRepository clientesRepository,
    IMapper mapper) : IClientesService
{
    public async Task<IEnumerable<ClientesDtoGetAll>> GetAllClientesAsync()
    {
        var clientes = await clientesRepository.GetAllAsync();
        if (clientes == null || !clientes.Any())
            throw new NotFoundException("No se encontraron clientes.");

        return mapper.Map<IEnumerable<ClientesDtoGetAll>>(clientes);
    }

    public async Task<ClientesDtoGetAll?> GetClienteByIdAsync(Guid id)
    {
        var cliente = await clientesRepository.GetByIdAsync(id);
        if (cliente == null)
            throw new NotFoundException($"Cliente con Id {id} no encontrado.");

        return mapper.Map<ClientesDtoGetAll>(cliente);
    }

    public async Task<bool> CreateClienteAsync(ClientesDtoAdd clienteDto)
    {
        var cliente = mapper.Map<Cliente>(clienteDto);
        await clientesRepository.AddAsync(cliente);
        await clientesRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateClienteAsync(ClientesDtoUpdate clienteDto)
    {
        var existing = await clientesRepository.GetByIdAsync(clienteDto.Id);
        if (existing == null)
            throw new NotFoundException($"Cliente con Id {clienteDto.Id} no encontrado.");

        existing.Nombre = clienteDto.Nombre;
        existing.Email = clienteDto.Email;
        existing.Direccion = clienteDto.Direccion;
        existing.Telefono = clienteDto.Telefono;

        clientesRepository.Update(existing);
        await clientesRepository.SaveChangesAsync();
        return true;
    }

    public async Task<ClientesDtoRemove> DeleteClienteAsync(Guid id)
    {
        var cliente = await clientesRepository.GetByIdAsync(id);
        if (cliente == null)
            throw new NotFoundException($"Cliente con Id {id} no encontrado.");

        clientesRepository.Delete(cliente);
        await clientesRepository.SaveChangesAsync();

        return new ClientesDtoRemove
        {
            ClienteId = id,
            Eliminado = true
        };
    }
}
