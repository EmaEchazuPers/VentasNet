using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly VentasNetContext _context;

        public UsuarioRepo(VentasNetContext context)
        {
            _context = context;
        }

        public Usuario GetUsuario(string userName, string passUser)
        {
            var usuario = _context.Usuario.Where(x => x.UserName == userName && x.Password == passUser).FirstOrDefault();

            return usuario;
        }

        public bool ExisteUsuario(UsuarioReq usu)
        {
            var usuario = GetUsuario(usu.UserName, usu.Password);

            if(usuario != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
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
                        var usuarioNew = MapeoUsuario(usu);
                        usuarioNew.Estado = true;
                        usuarioNew.FechaAlta = DateTime.Now;

                        _context.Add(usuarioNew);
                        _context.SaveChanges();
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

        public Usuario MapeoUsuario(UsuarioReq usu)
        {
            Usuario usuario = new Usuario()
            {
                IdUsuario     = usu.IdUsuario     ,
                UserName      = usu.UserName      ,
                Password      = usu.Password      ,
                Email         = usu.Email         ,
                Estado        = usu.Estado        ,
                IdTipoUsuario = usu.IdTipoUsuario ,
                FechaAlta     = usu.FechaAlta     ,
                FechaBaja     = usu.FechaBaja      
            };

            return usuario;
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

        public UsuarioResponse UpdateUsuario(UsuarioReq usu)
        {
            UsuarioResponse usuarioResponse = new UsuarioResponse();

            var existeUsuario = GetUsuario(usu.UserName, usu.Password);

            if (existeUsuario != null)
            {
                try
                {
                    existeUsuario.UserName = usu.UserName == null ? string.Empty : usu.UserName;
                    existeUsuario.Password = usu.Password == null ? string.Empty : usu.Password;
                    existeUsuario.Email = usu.Email == null ? string.Empty : usu.Email;
                    existeUsuario.IdTipoUsuario = usu.IdTipoUsuario == null ? 0 : usu.IdTipoUsuario;
                    

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
                    existeUsuario.Estado = false;
                    existeUsuario.FechaBaja = DateTime.Now;

                    _context.Update(existeUsuario);
                    _context.SaveChanges();

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
    }
}
