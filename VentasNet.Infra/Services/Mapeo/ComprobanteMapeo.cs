using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class ComprobanteMapeo
    {
        public static Comprobante ReqAModelo(ComprobanteReq objComprobante)
        {

            Comprobante comprobante = new Comprobante()
            {
                IdComprobante = objComprobante.IdComprobante,
                Nombre = objComprobante.Nombre,
                NombreCorto = objComprobante.NombreCorto,
                Descripcion = objComprobante.Descripcion,
                NroInicioCbte = objComprobante.NroInicioCbte,
                NroSucursal = objComprobante.NroSucursal,
                NroUltimoCbt = objComprobante.NroUltimoCbt,
                FechaMovimiento = objComprobante.FechaMovimiento
        
            };

            return comprobante;
        }

    }
}
