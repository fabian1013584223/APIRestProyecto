using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductoRepository> _productoRepository;
        private readonly Lazy<IStockRepository> _stockRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _productoRepository = new Lazy<IProductoRepository>(() => new
            ProductoRepository(repositoryContext));

            _stockRepository = new Lazy<IStockRepository>(() => new
            StockRepository(repositoryContext));
        }

        public IProductoRepository Producto => _productoRepository.Value;


        public IStockRepository Stock => _stockRepository.Value;


        public void Save()
        => _repositoryContext.SaveChanges();

    }
}
