using Microsoft.AspNetCore.Mvc;
using PrimeiraAppMVC.Models;

namespace PrimeiraApp.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            var aluno = new Aluno();

            if (TryValidateModel(aluno))
            {
                return View(aluno);
            }

            var ms = ModelState;

            var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            errors.ForEach(r  => Console.WriteLine(r.First().ErrorMessage));

            return View();
        }
    }
}
