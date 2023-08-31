using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ProductoNotFoundException : NotFoundException
    {
        public ProductoNotFoundException(Guid productoId)
            : base($"Producto with id: {productoId} doesn't exist in the database.")
        {
        }
    }

}
