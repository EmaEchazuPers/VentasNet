using VentasNet.Models;

namespace VentasNet.Repositories
{
    public class ProveedorRepo
    {
        public bool AgregarProveedor()
        {
            return false;
        }
        public void ModificarProveedor(Proveedor prov)
        {
            int index = Listados.ListaProveedor.FindIndex(x => x.Id == prov.Id);
            if (index != -1)
            {
                Listados.ListaProveedor[index].Cuit = prov.Cuit;
                Listados.ListaProveedor[index].RazonSocial = prov.RazonSocial;
                Listados.ListaProveedor[index].Domicilio = prov.Domicilio;
                Listados.ListaProveedor[index].Provincia = prov.Provincia;
            }
        }

        public bool VerificarProveedor(Proveedor prov)
        {
            bool existe = false;
            Proveedor existeProveedor = new Proveedor();

            existeProveedor = Listados.ListaProveedor.Find(x => x.Id == prov.Id);

            if (existeProveedor != null)
            {
                existe = true;
            }

            return existe;
        }

        internal void EliminarProveedor(int id)
        {
            int index = Listados.ListaProveedor.FindIndex(x => x.Id == id);
            Listados.ListaProveedor[index].Estado = false;
        }
    }
}
