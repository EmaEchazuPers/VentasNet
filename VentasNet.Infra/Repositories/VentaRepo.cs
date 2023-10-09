//using System.Security.Cryptography.X509Certificates;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public class VentaRepo : IVentaRepo
    {
        private readonly VentasNetContext _context;

        public VentaRepo(VentasNetContext context)
        {
            _context = context;
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
                        var productoNew = MapeoProducto(objProducto);

                        _context.Add(productoNew);
                        _context.SaveChanges();
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

        public Producto GetNombre(string nombre)
        {
            var producto = _context.Producto.Where(x => x.Nombre == nombre).FirstOrDefault();

            return producto;
        }

        public Producto MapeoProducto(ProductoReq objProducto)
        {
            Producto producto = new Producto()
            {
               IdProducto = objProducto.IdProducto,
               IdProveedor = objProducto.IdProveedor,
               Nombre     = objProducto.Nombre,
               Descripcion= objProducto.Descripcion,
               Importe    = objProducto.Importe      
            };

            return producto;
        }

        public ProductoResponse UpdateProducto(ProductoReq objProducto)
        {
            ProductoResponse productoResponse = new ProductoResponse();

            var existeProducto = GetNombre(objProducto.Nombre);

            if (existeProducto != null)
            {
                try
                {
                    existeProducto.IdProveedor = objProducto.IdProveedor == null ? 0 : objProducto.IdProveedor;
                    existeProducto.Descripcion = objProducto.Descripcion == null ? string.Empty : objProducto.Descripcion;
                    existeProducto.Nombre = objProducto.Nombre == null ? string.Empty : objProducto.Nombre;
                    existeProducto.Importe = objProducto.Importe == null ? 0 : objProducto.Importe;

                    _context.Update(existeProducto);
                    _context.SaveChanges();

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
                    _context.Remove(existeProducto);
                    _context.SaveChanges();

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

    }
}
