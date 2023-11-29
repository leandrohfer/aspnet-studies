using DemoInicialMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoInicialMVC.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aluno = new Aluno() { Nome = "Leandro" };

            return View(aluno);
        }
    }
}
