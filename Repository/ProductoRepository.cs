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

        public IEnumerable<Producto> GetAllProductos(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Nombre)
            .ToList();

    }
}
