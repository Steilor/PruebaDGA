using ClnArq.Application.Services;
using ClnArq.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers
{
    [ApiController]
    [Route("home")]
    public class StoreController(IStoreService storeService) : ControllerBase
    {
        private readonly IStoreService _storeService = storeService;

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
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
        public async Task<ActionResult<Producto>> Create([FromBody] Producto producto)
        {
            var created = await _storeService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Producto producto)
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
