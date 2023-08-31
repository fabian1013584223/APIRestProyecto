using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IEmployeeService
{
    IEnumerable<ProductoDTO> GetProducto(Guid productoId, bool trackChanges);
    ProductoDTO GetProducto(Guid productoId, Guid id, bool trackChanges);
    ProductoDTO CreateProductoForStock(Guid companyId, ProductoForCreationDTO employeeForCreation, bool trackChanges);
    void DeleteProductoForStock(Guid companyId, Guid id, bool trackChanges);
}
