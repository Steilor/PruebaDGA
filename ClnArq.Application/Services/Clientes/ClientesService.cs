using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Domain.Entities;
using ClnArq.Domain.Exceptions;
using ClnArq.Domain.Repositories;

namespace ClnArq.Application.Services.Clientes;

internal class ClientesService(IClientesRepository clientesRepository,
    IMapper mapper) : IClientesService
{
    public async Task<bool> CreateClienteAsync(ClienteDto clienteDto)
    {
        var cliente = mapper.Map<Cliente>(clienteDto);

        if (cliente == null)
            throw new NotFoundException();

        await clientesRepository.AddAsync(cliente);
        await clientesRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteClienteAsync(Guid id)
    {
        var cliente = await clientesRepository.GetByIdAsync(id);
        if (cliente == null)
            throw new NotFoundException();

        clientesRepository.Delete(cliente);
        await clientesRepository.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
    {
        var clientes = await clientesRepository.GetAllAsync();
        if (clientes == null)
            throw new NotFoundException();

        var clientesDto = mapper.Map<IEnumerable<ClienteDto>>(clientes);

        return clientesDto;
    }

    public async Task<ClienteDto?> GetClienteByIdAsync(Guid id)
    {
        var cliente = await clientesRepository.GetByIdAsync(id);

        if (cliente == null)
            throw new NotFoundException();
        var clienteDto = mapper.Map<ClienteDto>(cliente);

        return clienteDto;
    }

    public async Task<bool> UpdateClienteAsync(ClienteDto clienteDto)
    {
        var exists = await clientesRepository.ExistsAsync(clienteDto.Id);
        if (!exists)
            return false;

        var cliente = mapper.Map<Cliente>(clienteDto);

        clientesRepository.Update(cliente);

        await clientesRepository.SaveChangesAsync();
        return true;
    }
}
