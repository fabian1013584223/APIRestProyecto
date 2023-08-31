using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IProductoService
{
    IEnumerable<ProductoDTO> GetProductos(Guid productoId, bool trackChanges);
    ProductoDTO GetProducto(Guid productoId, Guid id, bool trackChanges);
    ProductoDTO CreateProductoForStock(Guid Id, ProductoForCreationDTO productoForCreation, bool trackChanges);
    void DeleteProductoForStock(Guid Id, Guid id, bool trackChanges);
}
