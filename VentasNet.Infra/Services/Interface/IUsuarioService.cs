using VentasNet.Entity.Models;

namespace VentasNet.Infra.Services.Interface
{
    public interface IUsuarioService
    {
        public void CrearNuevoUsuario(Usuario usuario);
        public void ModificarUsuario(Usuario usuario);
        public void EliminarUsuario(int id);
    }
}
