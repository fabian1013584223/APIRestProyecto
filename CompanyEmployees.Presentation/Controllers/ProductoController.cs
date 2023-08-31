using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts; 
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/stock/{stockId}/productos/{productoId}")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProductoController(IServiceManager service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult GetProductosForStock(int stockId)
        {
            var productos = _service.ProductoService.GetProductos(stockId, trackChanges: false);
            return Ok(productos);
        }

        [HttpGet("{id:int}", Name = "GetProductoForStock")]
        public IActionResult GetProductoForStock(int stockId, int id)
        {
            var producto = _service.ProductoService.GetProducto(stockId, id, trackChanges: false);
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult CreateProductoForStock(int stockId, [FromBody] ProductoForCreationDTO producto)
        {
            if (producto == null)
                return BadRequest("ProductoForCreationDTO object is null");

            var productoToReturn = _service.ProductoService.CreateProductoForStock(stockId, producto, trackChanges: false);

            return CreatedAtRoute("GetProductoForStock", new { stockId, id = productoToReturn.Id },
                productoToReturn);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProductoForStock(int stockId, int id)
        {
            _service.ProductoService.DeleteProductoForStock(stockId, id, trackChanges: false);
            return NoContent();
        }
    }
}

