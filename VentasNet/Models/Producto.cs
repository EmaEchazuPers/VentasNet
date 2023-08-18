namespace VentasNet.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string? NombreProducto { get; set; }
        public string? Descripcion { get; set; }
        public double? ImporteProducto { get; set; }

    }
}
