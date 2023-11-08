using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Interfaces
{
    public interface IComprobanteRepo
    {
        public List<ComprobanteReq> GetComprobantes();
    }
}
