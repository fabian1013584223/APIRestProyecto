using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts; 
using Shared.DataTransferObjects;

namespace StockProductos.Presentation.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProductoController(IServiceManager service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult GetProductosForStock(Guid stockId)
        {
            var productos = _service.ProductoService.GetProductos(stockId, trackChanges: false);
            return Ok(productos);
        }

        [HttpGet("{id:guid}", Name = "GetProductoForStock")]
        public IActionResult GetProductoForStock(Guid stockId, Guid id)
        {
            var producto = _service.ProductoService.GetProducto(stockId, id, trackChanges: false);
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult CreateProductoForStock(Guid stockId, [FromBody] ProductoForCreationDTO producto)
        {
            if (producto == null)
                return BadRequest("ProductoForCreationDTO object is null");

            var productoToReturn = _service.ProductoService.CreateProductoForStock(stockId, producto, trackChanges: false);

            return CreatedAtRoute("GetProductoForStock", new { stockId, id = productoToReturn.Id },
                productoToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProductoForStock(Guid stockId, Guid id)
        {
            _service.ProductoService.DeleteProductoForStock(stockId, id, trackChanges: false);
            return NoContent();
        }
    }
}

