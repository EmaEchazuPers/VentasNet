using VentasNet.Models;

namespace VentasNet.Repositories
{
    public class UsuarioRepo
    { 
        public bool ExisteUsuario(Usuario usu)
        {
            Usuario auxiliar = new Usuario();
            auxiliar = Listados.ListaUsuario.Find(x => x.Id == 1);
            if(auxiliar.UserName.Equals(usu.UserName) && auxiliar.Password.Equals(usu.Password))
            {
                return true;
            }
            else
            { return false; }
        }

    }
}
