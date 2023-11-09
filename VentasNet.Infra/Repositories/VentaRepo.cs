using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Common;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Services.Interface;
using VentasNet.Infra.Services.Mapeo;

namespace VentasNet.Infra.Repositories
{
    public class VentaRepo : IVentaRepo
    {
        private readonly VentasNetContext _context;
        private readonly IProductoService _productoService;

        public VentaRepo(VentasNetContext context, IProductoService productoService)
        {
            _context = context;
            _productoService = productoService;
        }

        public ProductoResponse AddProducto(ProductoReq objProducto)
        {
            ProductoResponse productoResponse = new ProductoResponse();

            if (objProducto.Nombre != null)
            {
                var existeProducto = GetNombre(objProducto.Nombre);

                if (existeProducto == null)
                {
                    try
                    {
                        var productoNew = ProductoMapeo.ReqAModelo(objProducto);

                        _productoService.CrearNuevoProducto(productoNew);

                        productoResponse.Guardar = true;
                        productoResponse.Nombre = productoNew.Nombre;
                        productoResponse.Mensaje = "El producto se agrego";
                    }
                    catch (Exception ex)
                    {
                        productoResponse.Mensaje = "Ocurrio un error al agregar un producto";
                        productoResponse.Guardar = false;
                    }
                }
            }            
            return productoResponse;
        }

        public ProductoResponse UpdateProducto(ProductoReq objProducto)
        {
            ProductoResponse productoResponse = new ProductoResponse();

            var existeProducto = GetNombre(objProducto.Nombre);

            if (existeProducto != null)
            {
                try
                {
                    var producto = ValidarModelo.ValidarProducto(objProducto, existeProducto);

                    _productoService.ModificarProducto(producto);

                    productoResponse.Guardar = true;
                    productoResponse.Nombre = existeProducto.Nombre;
                    productoResponse.Mensaje = "El producto se modifico";
                }
                catch (Exception ex)
                {
                    productoResponse.Mensaje = "Ocurrio un error al modificar un producto";
                    productoResponse.Guardar = false;
                }

            }

            return productoResponse;
        }

        public ProductoResponse DeleteProducto(ProductoReq objProducto)
        {
            ProductoResponse productoResponse = new ProductoResponse();

            var existeProducto = GetNombre(objProducto.Nombre);

            if (existeProducto != null)
            {
                try
                {
                    _productoService.EliminarProducto(objProducto.IdProducto);

                    productoResponse.Guardar = true;
                    productoResponse.Mensaje = "El producto se elimino";

                }
                catch (Exception ex)
                {
                    productoResponse.Mensaje = "Ocurrio un error al eliminar un producto";
                    productoResponse.Guardar = false;
                }

            }

            return productoResponse;
        }

        public List<ProductoReq> GetProductos()
        {
            List<ProductoReq> listadoProductos = new List<ProductoReq>();

            var lista = _context.Producto.Where(x => x.Nombre != null).ToList();

            foreach (var item in lista)
            {
                ProductoReq producto = new ProductoReq();

                producto.IdProducto = item.IdProducto;
                producto.IdProveedor = item.IdProveedor;
                producto.Nombre = item.Nombre;
                producto.Descripcion = item.Descripcion;
                producto.Importe = item.Importe;

                listadoProductos.Add(producto);
            }
            return listadoProductos;
        }

        public Producto GetNombre(string nombre)
        {
            var producto = _context.Producto.Where(x => x.Nombre == nombre).FirstOrDefault();

            return producto;
        }

    }
}
