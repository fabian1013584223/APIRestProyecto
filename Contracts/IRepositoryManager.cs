using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IProductoRepository Producto { get; }
        IStockRepository Stock { get; }
        void Save();
    }
}
