using CompanyEmployees.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IServiceManager _service;

        public StockController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var stocks = _service.StockService.GetAllStocks(trackChanges: false);

            return Ok(stocks);
        }

        [HttpGet("{id:int}", Name = "StockById")]
        public IActionResult GetStock(int id)
        {
            var stock = _service.StockService.GetStock(id, trackChanges: false);
            return Ok(stock);
        }

        [HttpGet("collection/({ids})", Name = "StockCollection")]
        public IActionResult GetStockCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var stocks = _service.StockService.GetByIds(ids, trackChanges: false);

            return Ok(stocks);
        }

        [HttpPost]
        public IActionResult CreateStock([FromBody] StockForCreationDTO stock)
        {
            if (stock is null)
                return BadRequest("StockForCreationDto object is null");

            var createdStock = _service.StockService.CreateStock(stock);

            return CreatedAtRoute("StockById", new { id = createdStock.Id }, createdStock);
        }

        [HttpPost("collection")]
        public IActionResult CreateStockCollection([FromBody] IEnumerable<StockForCreationDto> stockCollection)
        {
            var result = _service.StockService.CreateStockCollection(stockCollection);

            return CreatedAtRoute("StockCollection", new { result.ids }, result.stocks);
        }
    }
}
