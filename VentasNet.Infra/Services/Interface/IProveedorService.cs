using VentasNet.Entity.Models;

namespace VentasNet.Infra.Services.Interface
{
    public interface IProveedorService
    {
        public void CrearNuevoProveedor(Proveedor proveedor);
        public void ModificarProveedor(Proveedor proveedor);
        public void EliminarProveedor(int id);
    }
}
