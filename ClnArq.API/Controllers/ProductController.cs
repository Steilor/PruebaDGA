using ClnArq.Application.Dtos.Productos;
using ClnArq.Application.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductController(IProductService _productService) : ControllerBase
    {
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductosDtoGetAll>>> GetAll()
        {
            var productos = await _productService.GetAllProductosAsync();
            return Ok(productos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductosDtoGetAll>> GetById(Guid id)
        {
            var producto = await _productService.GetProductoByIdAsync(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

   
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductosDtoAdd producto)
        {
            await _productService.CreateProductoAsync(producto);
            return NoContent();
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductosDtoUpdate producto)
        {
            if (id == Guid.Empty)
                return BadRequest("ID null");

            producto.Id = id;

            var updated = await _productService.UpdateProductoAsync(producto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductosDtoRemove>> Delete(Guid id)
        {
            var result = await _productService.DeleteProductoAsync(id);

            if (!result.Eliminado)
                return NotFound();

            return Ok(result);
        }
    }
}
