using VentasNet.Infra.DTO.Request;

namespace VentasNet.Models
{
    public static class Listados
    {
        //Se instancia los listados para que no se rompan las vistas
        //Son estáticos para que perduren durante la ejecución de la app
        public static List<ClienteReq> ListaCliente { get; set; } = new List<ClienteReq>();
        public static List<ProveedorReq> ListaProveedor { get; set; } = new List<ProveedorReq>();
        public static List<ProductoReq> ListaProducto { get; set;} = new List<ProductoReq>();
        public static List<ProductoVendido> ListaProductoVendido { get; set; } = new List<ProductoVendido>();
        public static List<VentaReq> ListaVenta { get; set; } = new List<VentaReq>();
        public static List<UsuarioReq> ListaUsuario { get; set; } = new List<UsuarioReq>();
    }
}
