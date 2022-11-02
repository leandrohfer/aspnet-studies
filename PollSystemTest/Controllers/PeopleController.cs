using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PollSystemTest.Models;

namespace PollSystemTest.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CountList = Repository.ListUsers.Count();
            return View(Repository.ListUsers);
        }

        [HttpGet]
        public IActionResult Registration(int? id)
        {
            var userexists = Repository.ListUsers.SingleOrDefault(u => u.Id == id);
            if (userexists != null)
            {
                return View(userexists);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(User user)
        {
            Repository.Save(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var userexists = Repository.ListUsers.SingleOrDefault(u => u.Id == id);
            if (userexists != null)
            {
                return View(userexists);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (User user)
        {
            var userexists = Repository.ListUsers.SingleOrDefault(u => u.Id == user.Id);
            if (userexists != null)
            {
                TempData["StatusDelete"] = Repository.Delete(user.Id);
            }
            else
            {
                TempData["StatusDelete"] = false;
            }
            return RedirectToAction("Index");
        }
    }
}
