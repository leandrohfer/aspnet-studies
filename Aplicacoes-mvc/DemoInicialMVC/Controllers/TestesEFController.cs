using DemoInicialMVC.Data;
using DemoInicialMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoInicialMVC.Controllers
{
    public class TestesEFController : Controller
    {
        public AppDbContext Db { get; set; }

        public TestesEFController(AppDbContext db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Leandro",
                Email = "hello@leandro.com",
                DataNascimento = new DateTime(2001, 06, 27),
                Avaliacao = 5,
                Ativo = true
            };

            // Insert
            Db.Alunos.Add(aluno);
            Db.SaveChanges();

            // Select
            var alunosChange = Db.Alunos.Where(a => a.Nome == "Leandro").FirstOrDefault();
            // var alunosChange = Db.Alunos.Where(a => a.Nome.Contains("Leandro")).FirstOrDefault(); // utilizando Like
            alunosChange.Nome = "Leandro Henrique";

            // Update
            Db.Alunos.Update(alunosChange);
            Db.SaveChanges();

            // Delete
            Db.Alunos.Remove(alunosChange);
            Db.SaveChanges();

            return Content("Realizado!");
        }
    }
}
