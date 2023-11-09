using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.Interfaces;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Controllers
{
    public class ComprobanteController : Controller
    {
        IComprobanteRepo _comprobanteRepo;

        public ComprobanteController(IComprobanteRepo comprobanteRepo)
        {
            _comprobanteRepo = comprobanteRepo;
        }

        public IActionResult ListadoComprobantes()
        {
            ViewBag.Comprobante = _comprobanteRepo.GetComprobantes();
            return View();
        }

        public IActionResult CrearComprobante()
        {
            ViewBag.Productos = _comprobanteRepo.GetProductos();
            ViewBag.Clientes = _comprobanteRepo.GetClientes();

            return View();
        }

        public IActionResult GuardarComprobante(ComprobanteReq comprobante)
        {
            //var comprobanteResponse = _comprobanteRepo.AddComprobante(comprobante);

            return RedirectToAction("ListadoComprobantes");
        }

    }
}
