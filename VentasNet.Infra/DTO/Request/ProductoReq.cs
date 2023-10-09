namespace VentasNet.Infra.DTO.Request
{
    public class ProductoReq
    {
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Importe { get; set; }

    }
}
