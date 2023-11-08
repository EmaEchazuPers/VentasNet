using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class UsuarioMapeo
    {
        public static Usuario ReqAModelo(UsuarioReq usu)
        {
            Usuario usuario = new Usuario()
            {
                IdUsuario = usu.IdUsuario,
                UserName = usu.UserName,
                Password = usu.Password,
                Email = usu.Email,
                Estado = usu.Estado,
                IdTipoUsuario = usu.IdTipoUsuario,
                FechaAlta = usu.FechaAlta,
                FechaBaja = usu.FechaBaja
            };

            return usuario;
        }
    }
}
