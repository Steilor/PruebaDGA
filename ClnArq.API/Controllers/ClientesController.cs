using ClnArq.Application.Dtos.Clientes;
using ClnArq.Application.Services.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController(IClientesService clientesService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientesDtoGetAll>>> GetAllClientes()
    {
        var clientes = await clientesService.GetAllClientesAsync();
        return Ok(clientes);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ClientesDtoGetAll>> GetById(Guid id)
    {
        var cliente = await clientesService.GetClienteByIdAsync(id);
        return Ok(cliente);
    }


    [HttpPost]
    public async Task<IActionResult> CreateCliente([FromBody] ClientesDtoAdd dto)
    {
        await clientesService.CreateClienteAsync(dto);
        return NoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ClientesDtoUpdate dto) //Aqui quite el id del parametro. probar la asignacion
    {
        dto.Id = id;
        var updated = await clientesService.UpdateClienteAsync(dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<ClientesDtoRemove>> Delete(Guid id)
    {
        var result = await clientesService.DeleteClienteAsync(id);

        if (!result.Eliminado)
            return NotFound();

        return Ok(result);
    }
}
