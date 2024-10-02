using Microsoft.AspNetCore.Mvc;
using PrimeiraAppMVC.Models;

namespace PrimeiraAppMVC.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aluno = new Aluno() { Nome = "Vitor" };

            return View(aluno);
        }
    }
}
