using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Interfaces
{
    public interface IComprobanteRepo
    {
        public List<ComprobanteReq> GetComprobantes();

        public List<Producto> GetProductos();

        public List<Cliente> GetClientes();

        public void AddComprobante(ComprobanteReq objComprobante);
    }
}
