using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
