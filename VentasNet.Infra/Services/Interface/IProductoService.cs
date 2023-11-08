using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;

namespace VentasNet.Infra.Services.Interface
{
    public interface IProductoService
    {
        public void CrearNuevoProducto(Producto producto);
        public void ModificarProducto(Producto producto);
        public void EliminarProducto(int id);
    }
}
