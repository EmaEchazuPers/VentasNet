using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Infra.Repositories;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {
        IClienteRepo clienteRepo;

        public ClienteController(IClienteRepo _clienteRepo)
        {
            clienteRepo = _clienteRepo;
        }
        

        //Vista del listado
        public IActionResult Listado() 
        {
            ViewBag.Cliente = clienteRepo.GetClientes();

            return View();
        }

        public IActionResult AgregarCliente(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.AddCliente(cli);

            return View();
        }

        
        public IActionResult GuardarCliente(ClienteReq cli) 
        {
            var clienteResponse = clienteRepo.AddCliente(cli);

            return RedirectToAction("Listado");
        }


        public IActionResult UpdateCliente(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.UpdateCliente(cli);

            return RedirectToAction("Listado");
        }


        public IActionResult ModificarCliente(ClienteReq cli)
        {
            var cliente = clienteRepo.GetClienteCuit(cli.Cuit);

            return View();
        }

        public IActionResult Delete(ClienteReq cli) 
        {
            var clienteResponse = clienteRepo.Delete(cli);

            return RedirectToAction("Listado");
        }
    }
}
