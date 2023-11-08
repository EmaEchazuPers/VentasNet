using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
