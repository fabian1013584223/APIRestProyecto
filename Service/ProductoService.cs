using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;
using Shared.DataTransferObjects;
using AutoMapper;
using Contracts;

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

        public IEnumerable<ProductoDTO> GetAllProductos(bool trackChanges)
        {
            var productos = _repository.Producto.GetAllProductos(trackChanges);
            var productosDTO = productos.Select(c => new ProductoDTO(c.Id, c.Nombre ?? " ", c.Precio)).ToList(); //!atención                
            return productosDTO;
        }
    }
}