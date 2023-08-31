using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICompanyService
{
    IEnumerable<StockDTO> GetAllStocks(bool trackChanges);
    StockDTO GetStock(Guid stockId, bool trackChanges);
    StockDTO CreateStock(StockForCreationDTO stock);
    IEnumerable<StockDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<StockDTO> stock, string ids) CreateStockCollection
        (IEnumerable<StockForCreationDTO> companyCollection);
}
