using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Common;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Services.Interface;
using VentasNet.Infra.Services.Mapeo;

namespace VentasNet.Infra.Repositories
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly VentasNetContext _context;

        private readonly IUsuarioService _usuarioService;

        public UsuarioRepo(VentasNetContext context, IUsuarioService usuarioService)
        {
            _context = context;
            _usuarioService = usuarioService;
        }

        public UsuarioResponse AddUsuario(UsuarioReq usu)
        {
            UsuarioResponse usuarioResponse = new UsuarioResponse();

            if (usu.UserName != null)
            {
                var existeUsuario = GetUsuario(usu.UserName,usu.Password); 

                if (existeUsuario == null)
                {
                    try
                    {
                        var usuarioNew = UsuarioMapeo.ReqAModelo(usu);

                        usuarioNew.Estado = true;
                        usuarioNew.FechaAlta = DateTime.Now;

                        _usuarioService.CrearNuevoUsuario(usuarioNew);

                        
                        usuarioResponse.Guardar = true;
                        usuarioResponse.Mensaje = "Se agrego el usuario";
                    }
                    catch (Exception ex)
                    {
                        usuarioResponse.Mensaje = "Ocurrio un error al agregar usuario";
                        usuarioResponse.Guardar = false;
                    }

                }
            }

            return usuarioResponse;
        }

        public UsuarioResponse UpdateUsuario(UsuarioReq usu)
        {
            UsuarioResponse usuarioResponse = new UsuarioResponse();

            var existeUsuario = GetUsuario(usu.UserName, usu.Password);

            if (existeUsuario != null)
            {
                try
                {
                    var usuario = ValidarModelo.ValidarUsuario(usu, existeUsuario);

                    _usuarioService.ModificarUsuario(usuario);

                    _context.Update(existeUsuario);
                    _context.SaveChanges();

                    usuarioResponse.Guardar = true;
                    usuarioResponse.Mensaje = "Se modifico el usuario";
                }
                catch (Exception ex)
                {
                    usuarioResponse.Mensaje = "Ocurrio un error al modificar usuario";
                    usuarioResponse.Guardar = false;
                }

            }

            return usuarioResponse;
        }

        public UsuarioResponse DeleteUsuario(UsuarioReq usu)
        {
            UsuarioResponse usuarioResponse = new UsuarioResponse();

            var existeUsuario = GetUsuario(usu.UserName, usu.Password);

            if (existeUsuario != null)
            {
                try
                {
                    _usuarioService.EliminarUsuario(existeUsuario.IdUsuario);

                    usuarioResponse.Guardar = true;
                    usuarioResponse.Mensaje = "Se elimino el usuario";

                }
                catch (Exception ex)
                {
                    usuarioResponse.Mensaje = "Ocurrio un error al eliminar usuario";
                    usuarioResponse.Guardar = false;
                }
            }

            return usuarioResponse;
        }

        public Usuario GetUsuario(string userName, string passUser)
        {
            var usuario = _context.Usuario.Where(x => x.UserName == userName && x.Password == passUser).FirstOrDefault();

            return usuario;
        }

        public bool ExisteUsuario(UsuarioReq usu)
        {
            var usuario = GetUsuario(usu.UserName, usu.Password);

            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UsuarioReq> GetListaUsuarios()
        {
            List<UsuarioReq> listadoUsuarios = new List<UsuarioReq>();

            var lista = _context.Usuario.Where(x => x.Estado != false).ToList();

            foreach (var item in lista)
            {
                UsuarioReq usuario = new UsuarioReq();

                usuario.UserName = item.UserName;
                usuario.Password = item.Password;
                usuario.Email = item.Email;
                usuario.IdTipoUsuario = item.IdTipoUsuario;
                usuario.Estado = item.Estado;
                usuario.FechaAlta = item.FechaAlta;
                usuario.FechaBaja = item.FechaBaja;

                listadoUsuarios.Add(usuario);
            }
            return listadoUsuarios;
        }
    }
}
