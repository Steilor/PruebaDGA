using ClnArq.API.Controllers;
using ClnArq.Application.Dtos;
using ClnArq.Application.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClnArq.Tests.API.Controllers
{
    public class StoreControllerTests
    {
        private readonly Mock<IProductService> _mockStoreService;
        private readonly ProductController _controller;

        public StoreControllerTests()
        {
            _mockStoreService = new Mock<IProductService>();
            _controller = new ProductController(_mockStoreService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithProductos()
        {
            // Arrange
            var productos = new List<ProductoDto> { new ProductoDto { Id = Guid.NewGuid(), Nombre = "Producto1" } };
            _mockStoreService.Setup(s => s.GetAllProductosAsync()).ReturnsAsync(productos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnProductos = Assert.IsAssignableFrom<IEnumerable<ProductoDto>>(okResult.Value);
            Assert.Single(returnProductos);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenProductoIsNull()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockStoreService.Setup(s => s.GetProductoByIdAsync(id)).ReturnsAsync((ProductoDto?)null);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateProduct_ReturnsNoContent()
        {
            // Arrange
            var productoDto = new ProductoDto { Id = Guid.NewGuid(), Nombre = "Nuevo" };
            _mockStoreService.Setup(s => s.CreateProductoAsync(productoDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.CreateProduct(productoDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var productoDto = new ProductoDto { Id = Guid.NewGuid(), Nombre = "Test" };

            // Act
            var result = await _controller.Update(Guid.NewGuid(), productoDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("ID mismatch", badRequest.Value);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenUpdateFails()
        {
            // Arrange
            var id = Guid.NewGuid();
            var productoDto = new ProductoDto { Id = id, Nombre = "Test" };
            _mockStoreService.Setup(s => s.UpdateProductoAsync(productoDto)).ReturnsAsync(false);

            // Act
            var result = await _controller.Update(id, productoDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenSuccessful()
        {
            var id = Guid.NewGuid();
            _mockStoreService.Setup(s => s.DeleteProductoAsync(id)).ReturnsAsync(true);

            var result = await _controller.Delete(id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenUnsuccessful()
        {
            var id = Guid.NewGuid();
            _mockStoreService.Setup(s => s.DeleteProductoAsync(id)).ReturnsAsync(false);

            var result = await _controller.Delete(id);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
