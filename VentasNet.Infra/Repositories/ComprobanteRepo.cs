using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Services.Mapeo;

namespace VentasNet.Infra.Repositories
{
    public class ComprobanteRepo : IComprobanteRepo
    {
        private readonly VentasNetContext _context;

        public ComprobanteRepo(VentasNetContext context)
        {
            _context = context;
        }

        public void AddComprobante(ComprobanteReq objComprobante) 
        {
            ComprobanteResponse comprobanteResponse = new ComprobanteResponse();

            if(objComprobante.Nombre != null) 
            {
                try
                {
                    var comprobanteNew = ComprobanteMapeo.ReqAModelo(objComprobante);

                    comprobanteNew.FechaMovimiento = DateTime.Now;

                    _context.Add(comprobanteNew);
                    _context.SaveChanges();

                    comprobanteResponse.Guardar = true;
                    comprobanteResponse.Nombre = comprobanteNew.Nombre;
                    comprobanteResponse.Mensaje = "Se agrego correctamente el comprobante";

                }
                catch(Exception ex)
                {
                    comprobanteResponse.Mensaje = "Ocurrio un error al agregar el comprobante";
                    comprobanteResponse.Guardar = false;
                }
            }
        }

        public List<ComprobanteReq> GetComprobantes()
        {
            List<ComprobanteReq> listadoComprobantes = new List<ComprobanteReq>();

            var lista = _context.Comprobante.Where(x => x.IdComprobante != null).ToList();

            foreach (var item in lista)
            {
                ComprobanteReq comprobante = new ComprobanteReq();

                comprobante.Nombre = item.Nombre;
                comprobante.Descripcion  = item.Descripcion;
                comprobante.NroSucursal = item.NroSucursal;
                comprobante.NroInicioCbte = item.NroInicioCbte;
                comprobante.NroUltimoCbt = item.NroUltimoCbt;

                listadoComprobantes.Add(comprobante);
            }
            return listadoComprobantes;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> listaProductos = new List<Producto> ();

            var lista = _context.Producto.Where(x => x.IdProducto != 0).ToList();

            foreach(var item in lista)
            {
                Producto producto = new Producto();

                producto.Nombre = item.Nombre;
                producto.Descripcion = item.Descripcion;
                producto.Importe = item.Importe;
                producto.IdProveedor = item.IdProveedor;

                listaProductos.Add(producto);
            }

            return listaProductos;
        }

        public List<Cliente> GetClientes() 
        {
            List<Cliente> listaClientes = new List<Cliente>();

            var lista = _context.Cliente.Where(x => x.Estado != false).ToList();

            foreach(var item in lista)
            {
                Cliente cliente = new Cliente();

                cliente.Nombre= item.Nombre;
                cliente.Cuit = item.Cuit;
                cliente.RazonSocial = item.RazonSocial;

                listaClientes.Add(cliente);

            }

            return listaClientes;
        }

        public void SaveCliente(Cliente cliente)
        {

        }

    }
}