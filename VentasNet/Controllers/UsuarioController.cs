using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Repositories;

namespace VentasNet.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioRepo usuarioRepo = new UsuarioRepo();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult IngresoUsuario(Usuario usuario)
        {

            bool existe = false;

            existe = usuarioRepo.ExisteUsuario(usuario);

            if(existe)
            {
                return Redirect("~/Cliente/Listado");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
