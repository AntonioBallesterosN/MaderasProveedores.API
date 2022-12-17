using Microsoft.AspNetCore.Mvc;

namespace MaderasProveedores.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
