using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects;

public record StockForCreationDTO(int Id, int CantidadMinima, int CantidadReal,
    IEnumerable<ProductoForCreationDTO> Productos);
