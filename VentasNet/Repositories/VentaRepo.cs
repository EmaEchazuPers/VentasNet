using System.Security.Cryptography.X509Certificates;
using VentasNet.Models;

namespace VentasNet.Repositories
{
    public class VentaRepo
    {
        private Venta _venta = new Venta();

        public VentaRepo() { }

        public Venta VentaMostrador()
        {
            return _venta;
        }

        internal void EliminarProducto(int id)
        {
            Producto auxiliar = new Producto();
            auxiliar = Listados.ListaProducto.Find(x => x.Id == id);

            Listados.ListaProducto.Remove(auxiliar);

        }

        internal void ModificarProducto(Producto prod)
        {
            int index = Listados.ListaProducto.FindIndex(x => x.Id == prod.Id);
            if (index != -1)
            {
                Listados.ListaProducto[index].IdProveedor = prod.IdProveedor;
                Listados.ListaProducto[index].NombreProducto = prod.NombreProducto;
                Listados.ListaProducto[index].Descripcion = prod.Descripcion;
                Listados.ListaProducto[index].ImporteProducto = prod.ImporteProducto;
            }
        }

        internal bool VerificarProducto(Producto prod)
        {
            bool existe = false;
            Producto existeProducto = new Producto();

            existeProducto = Listados.ListaProducto.Find(x => x.Id == prod.Id);

            if (existeProducto != null)
            {
                existe = true;
            }

            return existe;
        }
    }
}
