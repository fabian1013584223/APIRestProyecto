using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace Service
{
    internal sealed class StockService : IStockService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StockService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<StockDTO> GetAllStocks(bool trackChanges)
        {
            var stocks = _repository.Stock.GetAllStocks(trackChanges);
            var stocksDTO = _mapper.Map<IEnumerable<StockDTO>>(stocks);
            return stocksDTO;
        }

        public StockDTO GetStock(Guid id, bool trackChanges)
        {
            var stock = _repository.Stock.GetStock(id, trackChanges);
            if (stock is null)
                throw new StockNotFoundException(id);

            var stockDTO = _mapper.Map<StockDTO>(stock);
            return stockDTO;
        }

        public StockDTO CreateStock(StockForCreationDTO stock)
        {
            var stockEntity = _mapper.Map<Stock>(stock);

            _repository.Stock.CreateStock(stockEntity);
            _repository.Save();

            var stockToReturn = _mapper.Map<StockDTO>(stockEntity);

            return stockToReturn;
        }

        public IEnumerable<StockDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var stockEntities = _repository.Stock.GetByIds(ids, trackChanges);
            if (ids.Count() != stockEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var stocksToReturn = _mapper.Map<IEnumerable<StockDTO>>(stockEntities);

            return stocksToReturn;
        }

        public (IEnumerable<StockDTO> stocks, string ids) CreateStockCollection
            (IEnumerable<StockForCreationDTO> stockCollection)
        {
            if (stockCollection is null)
                throw new StockCollectionBadRequest();

            var stockEntities = _mapper.Map<IEnumerable<Stock>>(stockCollection);
            foreach (var stock in stockEntities)
            {
                _repository.Stock.CreateStock(stock);
            }

            _repository.Save();

            var stockCollectionToReturn = _mapper.Map<IEnumerable<StockDTO>>(stockEntities);
            var ids = string.Join(",", stockCollectionToReturn.Select(c => c.stockId));

            return (companies: stockCollectionToReturn, ids: ids);
        }
    }
}