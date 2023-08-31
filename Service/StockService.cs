using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;
using Service.Contracts;
using AutoMapper;
using Contracts;


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
            try
            {
                var stocks = _repository.Stock.GetAllStocks(trackChanges);

                //var companiesDTO = companies.Select(c => new CompanyDTO(c.Id, c.Name ?? " ", string.Join(' ', c.Address, c.Country))).ToList(); //!atención 

                var stocksDTO = _mapper.Map<IEnumerable<StockDTO>>(stocks);

                return stocksDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllStocks)} service method {ex}");
                throw;
            }
        }

    }
}
