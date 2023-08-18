using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Repositories;

namespace VentasNet.Controllers
{
    public class ProveedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        ProveedorRepo proveedorRepo = new ProveedorRepo();

        public IActionResult ListadoProveedores()
        {
            ViewBag.Proveedor = Listados.ListaProveedor.Where(x=>x.Estado == true);
            return View();
        }

        public IActionResult AgregarProveedor(Proveedor prov)
        {
            return View();
        }

        public IActionResult Modificar(int id)
        {
            Proveedor prov = new Proveedor();
            prov = Listados.ListaProveedor.Find(x => x.Id == id);
            return RedirectToAction("AgregarProveedor", prov);
        }

        public IActionResult Borrar(int id) 
        {
            proveedorRepo.EliminarProveedor(id);
            return RedirectToAction("ListadoProveedores");

        }

        public IActionResult GuardarProveedor(Proveedor prov)
        {
            bool existe = false;

            existe = proveedorRepo.VerificarProveedor(prov);
            if (existe)
            {
                proveedorRepo.ModificarProveedor(prov);
            }
            else
            {
                prov.Estado = true;
                Listados.ListaProveedor.Add(prov);
            }
            return RedirectToAction("ListadoProveedores");
        }
    }
}
