using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaAppVS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAppVS.Controllers
{
    public class FilmeController : Controller
    {
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            if (ModelState.IsValid)
            {
            }

            return View(filme);
        }
    }
}
