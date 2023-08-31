using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStockService
{
    IEnumerable<StockDTO> GetAllStocks(bool trackChanges);
    StockDTO GetStock(Guid stockId, bool trackChanges);
    StockDTO CreateStock(StockForCreationDTO stock);
    IEnumerable<StockDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<StockDTO> stocks, string ids) CreateStockCollection
        (IEnumerable<StockForCreationDTO> stockCollection);
}
