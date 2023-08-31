using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Stock> GetAllStocks(bool trackChanges) =>
            FindAll(trackChanges)
        .OrderBy(c => c.stockId)
        .ToList();

        public Stock GetStock(Guid stockId, bool trackChanges) =>
            FindByCondition(c => c.stockId.Equals(stockId), trackChanges)
        .SingleOrDefault();
        public void CreateStock(Stock stock) => Create(stock);

        public IEnumerable<Stock> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
         FindByCondition(x => ids.Contains(x.stockId), trackChanges)
         .ToList();
    }
}