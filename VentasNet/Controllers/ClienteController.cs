using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;

namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado() 
        {
            List<Cliente> listadoCliente = new List<Cliente>();
            listadoCliente.Add(new Cliente() { Id = 1, RazonSocial = "Empresa 1", Cuit = "66473828922", Domicilio = "Centro", Provincia = "Salta" });

            //ViewBag es una clase genérica que me acepta lo que le pasemos

            ViewBag.Cliente = listadoCliente; 
            return View();
        }
    }
}
