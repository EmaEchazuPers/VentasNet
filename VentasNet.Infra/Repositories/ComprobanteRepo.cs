using VentasNet.Entity.Data;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Infra.Repositories
{
    public class ComprobanteRepo : IComprobanteRepo
    {
        private readonly VentasNetContext _context;

        public ComprobanteRepo(VentasNetContext context)
        {
            _context = context;
        }

        public List<ComprobanteReq> GetComprobantes()
        {
            List<ComprobanteReq> listadoComprobantes = new List<ComprobanteReq>();

            var lista = _context.Comprobante.Where(x => x.IdComprobante != null).ToList();

            foreach (var item in lista)
            {
                ComprobanteReq comprobante = new ComprobanteReq();

                comprobante.Nombre = item.Nombre;
                comprobante.Descripcion  = item.Descripcion;
                comprobante.NroSucursal = item.NroSucursal;
                comprobante.NroInicioCbte = item.NroInicioCbte;
                comprobante.NroUltimoCbt = item.NroUltimoCbt;

                listadoComprobantes.Add(comprobante);
            }
            return listadoComprobantes;
        }

    }
}