using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Common;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Services.Interface;
using VentasNet.Infra.Services.Mapeo;
using VentasNet.Infra.Services.Repo;
using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public class ProveedorRepo : IProveedorRepo
    {
        private readonly VentasNetContext _context;
        private readonly IProveedorService _proovedorService;

        public ProveedorRepo(VentasNetContext context, IProveedorService proovedorService)
        {
            _context = context;
            _proovedorService = proovedorService;
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
                        var proveedorNew = ProveedorMapeo.ReqAModelo(objProveedor);
                        
                        proveedorNew.Estado = true;
                        proveedorNew.FechaAlta = DateTime.Now;

                        _proovedorService.CrearNuevoProveedor(proveedorNew);

                       
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


        public ProveedorResponse UpdateProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    var proveedor = ValidarModelo.ValidarProveedor(objProveedor, existeProveedor);

                    _proovedorService.ModificarProveedor(proveedor);

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
                    _proovedorService.EliminarProveedor(existeProveedor.IdProveedor);

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

    }
}
