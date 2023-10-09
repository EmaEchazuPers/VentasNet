using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public class ProveedorRepo : IProveedorRepo
    {
        private readonly VentasNetContext _context;

        public ProveedorRepo(VentasNetContext context)
        {
            _context = context;
        }
        public object AddProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            if (objProveedor.Cuit != null)
            {
                var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

                if (existeProveedor == null)
                {
                    try
                    {
                        var proveedorNew = MapeoProveedor(objProveedor);
                        proveedorNew.Estado = true;
                        proveedorNew.FechaAlta = DateTime.Now;

                        _context.Add(proveedorNew);
                        _context.SaveChanges();
                        proveedorResponse.Guardar = true;
                        proveedorResponse.RazonSocial = proveedorNew.RazonSocial;
                        proveedorResponse.Mensaje = "Se agrego el proveedor";
                    }
                    catch (Exception ex)
                    {
                        proveedorResponse.Mensaje = "Ocurrio un error al agregar proveedor";
                        proveedorResponse.Guardar = false;
                    }

                }
            }

            return proveedorResponse;
        }

        public Proveedor MapeoProveedor(ProveedorReq objProveedor)
        {
            Proveedor proveedor = new Proveedor()
            {
                IdProveedor = objProveedor.IdProveedor,
                RazonSocial = objProveedor.RazonSocial,
                Cuit        = objProveedor.Cuit       ,
                Domicilio   = objProveedor.Domicilio  ,
                Provincia   = objProveedor.Provincia  ,
                Estado      = objProveedor.Estado     ,
                FechaAlta   = objProveedor.FechaAlta  ,
                FechaBaja   = objProveedor.FechaBaja
            };

            return proveedor;
        }

        public Proveedor GetProveedorCuit(string cuit)
        {
            var proveedor = _context.Proveedor.Where(x => x.Cuit == cuit).FirstOrDefault();

            return proveedor;
        }

        public List<ProveedorReq> GetProveedores()
        {
            List<ProveedorReq> listadoProveedores = new List<ProveedorReq>();

            var lista = _context.Proveedor.Where(x => x.Estado != false).ToList();

            foreach (var item in lista)
            {
                ProveedorReq proveedor = new ProveedorReq();

                proveedor.Cuit = item.Cuit;
                proveedor.Domicilio = item.Domicilio;
                proveedor.Provincia = item.Provincia;
                proveedor.RazonSocial = item.RazonSocial;
                proveedor.Estado = item.Estado;
                proveedor.FechaAlta = item.FechaAlta;
                proveedor.FechaBaja = item.FechaBaja;

                listadoProveedores.Add(proveedor);
            }
            return listadoProveedores;
        }

        public ProveedorResponse UpdateProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    existeProveedor.Cuit = objProveedor.Cuit == null ? string.Empty : objProveedor.Cuit;
                    existeProveedor.RazonSocial = objProveedor.RazonSocial == null ? string.Empty : objProveedor.RazonSocial;
                    existeProveedor.Domicilio = objProveedor.Domicilio == null ? string.Empty : objProveedor.Domicilio;
                    existeProveedor.Provincia = objProveedor.Provincia == null ? string.Empty : objProveedor.Provincia;

                    _context.Update(existeProveedor);
                    _context.SaveChanges();

                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = existeProveedor.RazonSocial;
                    proveedorResponse.Mensaje = "Se modifico el proveedor";
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Ocurrio un error al modificar proveedor";
                    proveedorResponse.Guardar = false;
                }

            }

            return proveedorResponse;
        }

        public ProveedorResponse DeleteProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    existeProveedor.Estado = false;
                    existeProveedor.FechaBaja = DateTime.Now;

                    _context.Update(existeProveedor);
                    _context.SaveChanges();

                    proveedorResponse.Guardar = true;
                    proveedorResponse.Mensaje = "Se elimino el proveedor";

                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Ocurrio un error al eliminar proveedor";
                    proveedorResponse.Guardar = false;
                }

            }

            return proveedorResponse;
        }

    }
}
