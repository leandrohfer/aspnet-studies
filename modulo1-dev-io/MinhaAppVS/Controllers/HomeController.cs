﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaAppVS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAppVS.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id:int}/{categoria:guid}")]
        public IActionResult Index(int id, Guid categoria)
        {
            return View();
        }

        [Route("privacidade")]
        [Route("politica-de-privacidade")]
        public IActionResult Privacy()
        {
            return Json("{'nome':'Leandro'}");
        }

        [Route("sobre")]
        public IActionResult About()
        {
            var fileBytes = System.IO.File.ReadAllBytes(@"C:\novo1765.txt");
            var fileName = "teste.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
