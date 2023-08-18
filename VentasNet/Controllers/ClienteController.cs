using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Repositories;


namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {   
        ClienteRepo clienteRepo = new ClienteRepo();

        //Vista del listado
        public IActionResult Listado() 
        {
            //ViewBag es una clase genérica que me acepta lo que le pasemos

            ViewBag.Cliente = Listados.ListaCliente.Where(x=>x.Estado == true);

            return View();
        }

        //Lógica del botón agregar cliente
        public IActionResult GuardarCliente(Cliente cli) 
        {
            bool existe = false;
            existe = clienteRepo.VerificarCliente(cli);

            if(existe) 
            {
                clienteRepo.ModificarCliente(cli);
            }
            else 
            {
                cli.Estado = true;
                Listados.ListaCliente.Add(cli); //Traigo la clase estática con sus atributos y métodos
            }
            return RedirectToAction("Listado"); //Redirijo al metodo listado
        }

        //Vista formulario de agregar cliente
        public IActionResult AgregarCliente(Cliente cli)
        {
            return View();
        }

        public IActionResult Edit(int id) 
        {
            Cliente cli = new Cliente();
            cli = Listados.ListaCliente.Find(x=>x.Id == id);
            return RedirectToAction("AgregarCliente",cli);
        }

        public IActionResult Delete(int id) 
        {
            clienteRepo.EliminarCliente(id);
            return RedirectToAction("Listado");
        }
    }
}
