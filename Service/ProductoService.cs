using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class ProductoService : IProductoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProductoDTO> GetProductos(Guid Id, bool trackChanges)
        {
            var stock = _repository.Stock.GetStock(Id, trackChanges);
            if (stock is null)
                throw new StockNotFoundException(Id);

            var productosFromDb = _repository.Producto.GetProductos(Id, trackChanges);
            var productosDTO = _mapper.Map<IEnumerable<ProductoDTO>>(productosFromDb);

            return productosDTO;
        }

        public ProductoDTO GetProducto(Guid Id, Guid id, bool trackChanges)
        {
            var stock = _repository.Stock.GetStock(Id, trackChanges);
            if (stock is null)
                throw new StockNotFoundException(Id);

            var productoDb = _repository.Producto.GetProducto(Id, id, trackChanges);
            if (productoDb is null)
                throw new ProductoNotFoundException(id);

            var producto = _mapper.Map<ProductoDTO>(productoDb);
            return producto;
        }

        public ProductoDTO CreateProductoForStock(Guid Id, ProductoForCreationDTO productoForCreation, bool trackChanges)
        {
            var stock = _repository.Stock.GetStock(Id, trackChanges);
            if (stock is null)
                throw new StockNotFoundException(Id);

            var productoEntity = _mapper.Map<Producto>(productoForCreation);

            _repository.Producto.CreateProductoForStock(Id, productoEntity);
            _repository.Save();

            var productoToReturn = _mapper.Map<ProductoDTO>(productoEntity);

            return productoToReturn;
        }

        public void DeleteProductoForStock(Guid Id, Guid id, bool trackChanges)
        {
            var stock = _repository.Stock.GetStock(Id, trackChanges);
            if (stock is null)
            {
                throw new StockNotFoundException(Id);
            }

            var productoForStock = _repository.Producto.GetProducto(Id, id, trackChanges);
            if (productoForStock is null)
            {
                throw new ProductoNotFoundException(id);
            }

            _repository.Producto.DeleteProducto(productoForStock);
            _repository.Save();
        }
    }
}