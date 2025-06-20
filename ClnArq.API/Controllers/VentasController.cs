using ClnArq.Application.Dtos.Ventas;
using ClnArq.Application.Services.Ventas;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentasController(IVentasService ventasService ) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentasDtoGetAll>>> GetAllVentas()
        {
            var ventas = await ventasService.GetAllVentasAsync();
            return Ok(ventas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VentasDtoGetAll>> GetById(int id)
        {
            var venta = await ventasService.GetVentaByIdAsync(id);
            return Ok(venta);
        }


        [HttpPost]
        public async Task<IActionResult> CreateVenta([FromBody] VentasDtoAdd venta)
        {
           await ventasService.CreateVentaAsync(venta);
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VentasDtoUpdate venta) //Aqui quite el id de parametro probar la asignacion
        {        
            venta.Id = id;
            var updated = await ventasService.UpdateVentaAsync(venta);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<VentasDtoRemove>> Delete(int id)
        {
            var result = await ventasService.DeleteVentaAsync(id);

            if (!result.Eliminado)
                return NotFound();

            return Ok(result);
        }
    }
}
