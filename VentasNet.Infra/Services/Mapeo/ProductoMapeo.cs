using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Services.Mapeo
{
    public class ProductoMapeo
    {
        public static Producto ReqAModelo(ProductoReq objProducto)
        {

            Producto producto = new Producto()
            {
                IdProducto = objProducto.IdProducto,
                IdProveedor = objProducto.IdProveedor,
                Nombre = objProducto.Nombre,
                Descripcion = objProducto.Descripcion,
                Importe = objProducto.Importe
            };

            return producto;
        }
    }
}
