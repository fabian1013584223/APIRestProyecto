using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    internal sealed class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
    {
        public ProductoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Producto> GetProductos(Guid stockId, bool trackChanges) =>
            FindByCondition(e => e.StockId.Equals(stockId), trackChanges)
            .OrderBy(e => e.Nombre)
            .ToList();

        public Producto GetProducto(Guid stockId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.StockId.Equals(stockId) && e.productoId.Equals(id), trackChanges)
            .SingleOrDefault();

        public void CreateProductoForStock(Guid stockId, Producto producto)
        {
            producto.StockId = stockId;
            Create(producto);
        }

        public void DeleteProducto(Producto producto) => Delete(producto);
    }
}

