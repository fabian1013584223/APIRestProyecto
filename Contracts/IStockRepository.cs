using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models; 

namespace Contracts
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAllStocks(bool trackChanges);
        Stock GetStock(Guid stockId, bool trackChanges);
        void CreateStock(Stock stock);
        IEnumerable<Stock> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    }
}
