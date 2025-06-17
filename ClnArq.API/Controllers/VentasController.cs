using ClnArq.Application.Dtos;
using ClnArq.Application.Services.Product;
using ClnArq.Application.Services.Ventas;
using ClnArq.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentasController(IVentasService ventasService ) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaDto>>> GetAllVentas()
        {
            var ventas = await ventasService.GetAllVentasAsync();
            return Ok(ventas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetById(int id)
        {
            var venta = await ventasService.GetVentaByIdAsync(id);
            return Ok(venta);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] VentaDto venta)
        {
           await ventasService.CreateVentaAsync(venta);
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VentaDto venta) //Aqui quite el id de parametro probar la asignacion
        {        
            venta.Id = id;
            var updated = await ventasService.UpdateVentaAsync(venta);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await ventasService.DeleteVentaAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
