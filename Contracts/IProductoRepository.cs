using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;


namespace Contracts
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetProductos(Guid productoId, bool trackChanges);
        Producto GetProducto(Guid productoId, Guid id, bool trackChanges);
        void CreateProductoForStock(Guid productoId, Producto producto);
        void DeleteProducto(Producto producto);
    }
}
