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
    public class ProductoService : IProductoService
    {
        private readonly VentasNetContext _context;

        public ProductoService(VentasNetContext context)
        {
            _context = context;
        }

        public void CrearNuevoProducto(Producto producto)
        {
            _context.Add(producto);
            _context.SaveChanges();

        }
        public void ModificarProducto(Producto producto)
        {
            var prod = _context.Producto.Where(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
            
            if (prod != null)
            {
                _context.Update(producto);
                _context.SaveChanges();
            }
        }

        public void EliminarProducto(int id)
        {
            var producto = _context.Producto.Where(x => x.IdProducto == id).FirstOrDefault();

            if (producto != null)
            {
                _context.Remove(producto);
                _context.SaveChanges();
            }

        }
    }
}
