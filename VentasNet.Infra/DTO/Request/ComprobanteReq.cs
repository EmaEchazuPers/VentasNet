using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasNet.Infra.DTO.Request
{
    public class ComprobanteReq
    {
        public int IdComprobante { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public int? NroInicioCbte { get; set; }
        public int? NroSucursal { get; set; }
        public int? NroUltimoCbt { get; set; }
        public DateTime? FechaMovimiento { get; set; }
    }
}
