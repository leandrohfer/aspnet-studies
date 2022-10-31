using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PollSystemTest.Models;

namespace PollSystemTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            return View(id);
        }

        [HttpGet]
        public IActionResult Reply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reply(Answer answer)
        {
            if (ModelState.IsValid)
            {
                Repository.AddAnswer(answer);
                return View("Thanks");
            }
            else
            {
                return View(answer);
            }
        }

        public IActionResult Result()
        {
            return View(Repository.Answers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}