using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.Services.Interface;

namespace VentasNet.Infra.Services.Repo
{
    public class UsuarioService : IUsuarioService
    {
        private readonly VentasNetContext _context;

        public UsuarioService(VentasNetContext context)
        {
            _context = context;
        }

        public void CrearNuevoUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();

        }
        public void ModificarUsuario(Usuario usuario)
        {
            var usu = _context.Usuario.Where(x => x.IdUsuario == usuario.IdUsuario).FirstOrDefault();
            
            if (usu != null)
            {
                usuario.Estado = false;
                usuario.FechaBaja = DateTime.Now;
                _context.Update(usuario);
                _context.SaveChanges();
            }
        }

        public void EliminarUsuario(int id)
        {
            var usu = _context.Usuario.Where(x => x.IdUsuario == id).FirstOrDefault();

            if (usu != null)
            {
                usu.Estado = false;
                usu.FechaBaja = DateTime.Now;
                _context.Update(usu);
                _context.SaveChanges();
            }

        }

    }
}
