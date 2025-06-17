using ClnArq.Application.Dtos;
using ClnArq.Application.Services;
using ClnArq.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentasController(IStoreService storeService) : ControllerBase
    {
        private readonly IStoreService _storeService = storeService;


        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
        {
            var productos = await _storeService.GetAllProductosAsync();
            return Ok(productos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(Guid id)
        {
            var producto = await _storeService.GetProductoByIdAsync(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductoDto producto)
        {
            var created = await _storeService.CreateProductoAsync(producto);
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductoDto producto)
        {
            if (id != producto.Id)
                return BadRequest("ID mismatch");

            var updated = await _storeService.UpdateProductoAsync(producto);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _storeService.DeleteProductoAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
