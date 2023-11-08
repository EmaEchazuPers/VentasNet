using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Services.Interface;

namespace VentasNet.Infra.Services.Repo
{
    public class ProveedorService : IProveedorService
    {
        private readonly VentasNetContext _context;

        public ProveedorService(VentasNetContext context)
        {
            _context = context;
        }

        public void CrearNuevoProveedor(Proveedor proveedor)
        {
            _context.Add(proveedor);
            _context.SaveChanges();

        }
        public void ModificarProveedor(Proveedor proveedor)
        {
            var prov = _context.Proveedor.Where(x => x.IdProveedor == proveedor.IdProveedor).FirstOrDefault();

            if (prov != null)
            {
                proveedor.Estado = false;
                proveedor.FechaBaja = DateTime.Now;
                _context.Update(proveedor);
                _context.SaveChanges();
            }
        }

        public void EliminarProveedor(int id)
        {
            var prov = _context.Proveedor.Where(x => x.IdProveedor == id).FirstOrDefault();

            if (prov != null)
            {
                prov.Estado = false;
                prov.FechaBaja = DateTime.Now;
                _context.Update(prov);
                _context.SaveChanges();

            }

        }
    }
}
