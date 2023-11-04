using VentasNet.Infra.DTO.Common;

namespace VentasNet.Infra.DTO.Response
{
    public class ClienteResponse : Mensajes
    {
        public string RazonSocial { get; set; }

        public bool Guardar { get; set; } = false;
    }
}
