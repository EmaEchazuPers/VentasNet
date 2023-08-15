using Microsoft.AspNetCore.Mvc;

namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
