using DemoInicialMVC.Data;
using DemoInicialMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoInicialMVC.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
