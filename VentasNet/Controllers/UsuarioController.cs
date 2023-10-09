using Microsoft.AspNetCore.Mvc;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;



namespace VentasNet.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioRepo usuarioRepo;

        public UsuarioController(IUsuarioRepo _usuarioRepo)
        {
            usuarioRepo = _usuarioRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult IngresoUsuario(UsuarioReq usuario)
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

        public IActionResult AddUsuario(UsuarioReq usu)
        {
            var usuario = usuarioRepo.AddUsuario(usu);

            return View();
        }

        public IActionResult ListadoUsuario()
        {
            ViewBag.Usuario = usuarioRepo.GetListaUsuarios();

            return View();
        }

        public IActionResult GuardarUsuario(UsuarioReq usu)
        {
            var usuario = usuarioRepo.AddUsuario(usu);

            return RedirectToAction("ListadoUsuario");
        }

        public IActionResult ModificarUsuario(UsuarioReq usu)
        {
            var usuario = usuarioRepo.GetUsuario(usu.UserName, usu.Password);

            return View();
        }

        public IActionResult UpdateUsuario(UsuarioReq usu)
        {
            var usuario = usuarioRepo.UpdateUsuario(usu);

            return RedirectToAction("ListadoUsuario");
        }

        public IActionResult DeleteUsuario(UsuarioReq usu)
        {
            var usuario = usuarioRepo.DeleteUsuario(usu);

            return RedirectToAction("ListadoUsuario");
        }
    }
}
