using ClnArq.API.Controllers;
using ClnArq.Application.Dtos.Productos;
using ClnArq.Application.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClnArq.Api.Tests;

public class StoreControllerTests
{
    private readonly Mock<IProductService> _mockService;
    private readonly ProductController _controller;

    public StoreControllerTests()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductController(_mockService.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOk_WithProductos()
    {
        var lista = new List<ProductosDtoGetAll> {
                new ProductosDtoGetAll { Id = Guid.NewGuid(), Nombre = "P1", Precio = 100, Stock = 1 }
            };
        _mockService.Setup(s => s.GetAllProductosAsync())
                    .ReturnsAsync(lista);

        var action = await _controller.GetAll();
        var ok = Assert.IsType<OkObjectResult>(action.Result);
        var model = Assert.IsAssignableFrom<IEnumerable<ProductosDtoGetAll>>(ok.Value);

        // Assert
        Assert.Single(model);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenNull()
    {
        var id = Guid.NewGuid();
        _mockService.Setup(s => s.GetProductoByIdAsync(id))
                    .ReturnsAsync((ProductosDtoGetAll?)null);

        var action = await _controller.GetById(id);

        // Assert
        Assert.IsType<NotFoundResult>(action.Result);
    }

    [Fact]
    public async Task CreateProduct_ReturnsNoContent()
    {
        var dto = new ProductosDtoAdd { Nombre = "X", Precio = 10, Stock = 5 };
        _mockService.Setup(s => s.CreateProductoAsync(dto))
                    .ReturnsAsync(true);

        var result = await _controller.CreateProduct(dto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenIdMismatch()
    {
        var dto = new ProductosDtoUpdate { Id = Guid.NewGuid(), Nombre = "X", Precio = 1, Stock = 1 };
        var routeId = Guid.NewGuid(); 

        var result = await _controller.Update(routeId, dto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenServiceReturnsFalse()
    {
        var id = Guid.NewGuid();
        var dto = new ProductosDtoUpdate { Id = id, Nombre = "X", Precio = 1, Stock = 1 };
        _mockService.Setup(s => s.UpdateProductoAsync(dto))
                    .ReturnsAsync(false);

        var result = await _controller.Update(id, dto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsOk_WithRemoveDto_WhenSuccessful()
    {
        var id = Guid.NewGuid();
        var removeDto = new ProductosDtoRemove { ProductoId = id, Eliminado = true };
        _mockService.Setup(s => s.DeleteProductoAsync(id))
                    .ReturnsAsync(removeDto);

        var action = await _controller.Delete(id);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(action.Result);
        var model = Assert.IsType<ProductosDtoRemove>(ok.Value);
        Assert.True(model.Eliminado);
        Assert.Equal(id, model.ProductoId);
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenServiceReturnsEliminadoFalse()
    {
        var id = Guid.NewGuid();
        var removeDto = new ProductosDtoRemove { ProductoId = id, Eliminado = false };
        _mockService.Setup(s => s.DeleteProductoAsync(id))
                    .ReturnsAsync(removeDto);

        var action = await _controller.Delete(id);

        Assert.IsType<NotFoundResult>(action.Result);
    }
}
