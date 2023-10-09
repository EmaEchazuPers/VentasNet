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
    public interface IProveedorRepo
    {
        public object AddProveedor(ProveedorReq objProveedor);
        public Proveedor MapeoProveedor(ProveedorReq objProveedor);
        public Proveedor GetProveedorCuit(string cuit);
        public List<ProveedorReq> GetProveedores();
        public ProveedorResponse UpdateProveedor(ProveedorReq objProveedor);
        public ProveedorResponse DeleteProveedor(ProveedorReq objProveedor);

    }
}
