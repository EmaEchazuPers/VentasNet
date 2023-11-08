using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class ProveedorMapeo
    {
        public static Proveedor ReqAModelo(ProveedorReq objProveedor)
        {
            Proveedor proveedor = new Proveedor()
            {
                IdProveedor = objProveedor.IdProveedor,
                RazonSocial = objProveedor.RazonSocial,
                Cuit = objProveedor.Cuit,
                Domicilio = objProveedor.Domicilio,
                Provincia = objProveedor.Provincia,
                Estado = objProveedor.Estado,
                FechaAlta = objProveedor.FechaAlta,
                FechaBaja = objProveedor.FechaBaja
            };

            return proveedor;
        }
    }
}
