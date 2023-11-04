using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepo _clienteRepo;

        public ClienteController(IClienteRepo clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public IActionResult AgregarCliente(ClienteReq cli)
        {
            var clienteResponse = _clienteRepo.AddCliente(cli);

            return View();
        }

        public IActionResult ModificarCliente(ClienteReq cli)
        {
            var cliente = _clienteRepo.GetClienteCuit(cli.Cuit);

            return View();
        }

        public IActionResult UpdateCliente(ClienteReq cli)
        {
            var clienteResponse = _clienteRepo.UpdateCliente(cli);

            return RedirectToAction("Listado");
        }

        public IActionResult GuardarCliente(ClienteReq cli)
        {
            var clienteResponse = _clienteRepo.AddCliente(cli);

            return RedirectToAction("Listado");
        } 

        public IActionResult Delete(ClienteReq cli) 
        {
            var clienteResponse = _clienteRepo.Delete(cli);

            return RedirectToAction("Listado");
        }

        public IActionResult Listado()
        {
            ViewBag.Cliente = _clienteRepo.GetClientes();

            return View();
        }
    }
}
