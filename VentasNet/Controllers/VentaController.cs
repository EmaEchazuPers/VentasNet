using Microsoft.AspNetCore.Mvc;
using System.IO.Pipes;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;
using VentasNet.Models;


namespace VentasNet.Controllers
{
    public class VentaController : Controller
    {
        IVentaRepo ventaRepo;
        public IActionResult Index()
        {
            return View();
        }

        public VentaController(IVentaRepo _ventaRepo)
        {
            ventaRepo = _ventaRepo;
        }

        public IActionResult ListadoProductos()
        {
            ViewBag.Producto = ventaRepo.GetProductos();
            return View();
        }

        public IActionResult ListadoVendidos()
        {
            //ViewBag.ProductoVendido = Listados.ListaProductoVendido;
            return View();
        }

        public IActionResult AgregarProducto(ProductoReq prod)
        {
            var productoResponse = ventaRepo.AddProducto(prod);

            return View();
        }

        public IActionResult GuardarProducto(ProductoReq prod)
        {
            var productoResponse = ventaRepo.AddProducto(prod);

            return RedirectToAction("ListadoProductos");
        }

        public IActionResult UpdateProducto(ProductoReq prod)
        {
            var productoResponse = ventaRepo.UpdateProducto(prod);

            return RedirectToAction("ListadoProductos");
        }

        public IActionResult ModificarProducto(ProductoReq prod)
        {
            var cliente = ventaRepo.GetNombre(prod.Nombre);

            return View();
        }
        public IActionResult BorrarProducto(ProductoReq prod)
        {
            var productoResponse = ventaRepo.DeleteProducto(prod);

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

        public IActionResult AgregarProductoVendido(ProductoVendido prod)
        {
            return View();
        }
    }
}
