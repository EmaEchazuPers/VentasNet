using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Interfaces
{
    public interface IUsuarioRepo
    {
        public UsuarioResponse AddUsuario(UsuarioReq usu);
        public bool ExisteUsuario(UsuarioReq usu);
        public Usuario GetUsuario(string userName, string passUser);
        public Usuario MapeoUsuario(UsuarioReq usu);
        public List<UsuarioReq> GetListaUsuarios();
        public UsuarioResponse UpdateUsuario(UsuarioReq usu);
        public UsuarioResponse DeleteUsuario(UsuarioReq usu);
    }
}
