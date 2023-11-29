using Microsoft.AspNetCore.Mvc;

namespace AppMvcSemTemplate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
