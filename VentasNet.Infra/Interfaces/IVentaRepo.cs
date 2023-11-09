using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Interfaces
{
    public interface IVentaRepo
    {
        public ProductoResponse AddProducto(ProductoReq objProducto);
        public Producto GetNombre(string nombre);        
        public ProductoResponse UpdateProducto(ProductoReq objProducto);
        public ProductoResponse DeleteProducto(ProductoReq objProducto);
        public List<ProductoReq> GetProductos();
    }
}
