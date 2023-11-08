using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;


namespace VentasNet.Controllers
{
    public class ProveedorController : Controller
    {
        IProveedorRepo proveedorRepo;

        public ProveedorController(IProveedorRepo _proveedorRepo)
        {
            proveedorRepo = _proveedorRepo;
        }

        public IActionResult ListadoProveedores()
        {
            
            ViewBag.Proveedor = proveedorRepo.GetProveedores();
            return View();
        }

        public IActionResult AgregarProveedor(ProveedorReq prov)
        {
            var proveedorResponse = proveedorRepo.AddProveedor(prov);

            return View();
        }

        public IActionResult GuardarProveedor(ProveedorReq prov)
        {
            var proveedorResponse = proveedorRepo.AddProveedor(prov);

            return RedirectToAction("ListadoProveedores");
        }

        public IActionResult UpdateProveedor(ProveedorReq prov) 
        {
            var proveedorResponse = proveedorRepo.UpdateProveedor(prov);

            return RedirectToAction("ListadoProveedores");
        }

        public IActionResult ModificarProveedor(ProveedorReq prov)
        {
            var proveedor = proveedorRepo.GetProveedorCuit(prov.Cuit);

            return View();
        }

        public IActionResult DeleteProveedor(ProveedorReq prov) 
        {
            var proveedorResponse = proveedorRepo.DeleteProveedor(prov);

            return RedirectToAction("ListadoProveedores");

        }

       
    }
}
