using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Models;


namespace VentasNet.Controllers
{
    public class VentaController : Controller
    {
        IVentaRepo _ventaRepo;
        public IActionResult Index()
        {
            return View();
        }

        public VentaController(IVentaRepo ventaRepo)
        {
            _ventaRepo = ventaRepo;
        }

        public IActionResult ListadoProductos()
        {
            ViewBag.Producto = _ventaRepo.GetProductos();
            return View();
        }

        public IActionResult ListadoVendidos()
        {
            return View();
        }

        public IActionResult AgregarProducto(ProductoReq prod)
        {
            var productoResponse = _ventaRepo.AddProducto(prod);

            return View();
        }

        public IActionResult GuardarProducto(ProductoReq prod)
        {
            var productoResponse = _ventaRepo.AddProducto(prod);

            return RedirectToAction("ListadoProductos");
        }

        public IActionResult UpdateProducto(ProductoReq prod)
        {
            var productoResponse = _ventaRepo.UpdateProducto(prod);

            return RedirectToAction("ListadoProductos");
        }

        public IActionResult ModificarProducto(ProductoReq prod)
        {
            var cliente = _ventaRepo.GetNombre(prod.Nombre);

            return View();
        }
        public IActionResult BorrarProducto(ProductoReq prod)
        {
            var productoResponse = _ventaRepo.DeleteProducto(prod);

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
