using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductoService> _productoService;
        private readonly Lazy<IStockService> _stockService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _productoService = new Lazy<IProductoService>(() => new ProductoService(repositoryManager, logger, mapper));
            _stockService = new Lazy<IStockService>(() => new StockService(repositoryManager, logger, mapper));
        }

        public IProductoService ProductoService => _productoService.Value;


        public IStockService StockService => _stockService.Value;
    }
}
