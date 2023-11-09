using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasNet.Infra.DTO.Response
{
    public class ComprobanteResponse
    {
        public string Nombre { get; set; }
        public string Mensaje { get; set; }

        public bool Guardar { get; set; } = false;
    }
}
