using Microsoft.AspNetCore.Mvc;
using System.IO.Pipes;
using VentasNet.Models;
using VentasNet.Repositories;

namespace VentasNet.Controllers
{
    public class VentaController : Controller
    {
        VentaRepo ventaRepo = new VentaRepo();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListadoProductos()
        {
            ViewBag.Producto = Listados.ListaProducto;
            return View();
        }

        public IActionResult ListadoVendidos()
        {
            ViewBag.ProductoVendido = Listados.ListaProductoVendido;
            return View();
        }

        public IActionResult AgregarProducto(Producto prod)
        {
            return View();
        }

        public IActionResult AgregarProductoVendido(ProductoVendido prod)
        {
            return View();
        }

        public IActionResult GuardarProducto(Producto prod)
        {
            bool existe = false;
            existe = ventaRepo.VerificarProducto(prod);

            if (existe)
            {
                ventaRepo.ModificarProducto(prod);
            }
            else
            {
                Listados.ListaProducto.Add(prod);
            }
            return RedirectToAction("ListadoProductos");
        }

        public IActionResult Modificar(int id)
        {
            Producto auxiliar = new Producto();
            auxiliar = Listados.ListaProducto.Find(x => x.Id == id);
            
            return RedirectToAction("AgregarProducto", auxiliar);
        }
        public IActionResult Borrar(int id)
        {
            ventaRepo.EliminarProducto(id);

            return RedirectToAction("ListadoProductos");
        }

        public IActionResult Vender(int id)
        {
            ProductoVendido producto = new ProductoVendido();
            producto.IdProducto = id;
            
            return RedirectToAction("AgregarProductoVendido",producto);
        }

        public IActionResult GuardarProductoVendido(ProductoVendido prod)
        {
            Listados.ListaProductoVendido.Add(prod);
            return RedirectToAction("ListadoVendidos");
        }

    }
}
