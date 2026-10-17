using Microsoft.AspNetCore.Mvc;

namespace MvcMonolithic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
