using ClnArq.Application.Dtos;
using ClnArq.Application.Services.Clientes;
using ClnArq.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController(IClientesService clientesService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAllVentas()
    {
        var clientes = await clientesService.GetAllClientesAsync();
        return Ok(clientes);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById(Guid id)
    {
        var cliente = await clientesService.GetClienteByIdAsync(id);
        return Ok(cliente);
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ClienteDto cliente)
    {
        await clientesService.CreateClienteAsync(cliente);
        return NoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ClienteDto cliente) //Aqui quite el id de parametro probar la asignacion
    {
        cliente.Id = id;
        var updated = await clientesService.UpdateClienteAsync(cliente);

        if (!updated)
            return NotFound();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await clientesService.DeleteClienteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
