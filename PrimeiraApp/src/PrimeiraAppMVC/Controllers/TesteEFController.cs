using Microsoft.AspNetCore.Mvc;
using PrimeiraAppMVC.Data;
using PrimeiraAppMVC.Models;

namespace PrimeiraAppMVC.Controllers
{
    public class TesteEFController : Controller
    {
        public AppDbContext Db { get; set; }

        public TesteEFController(AppDbContext db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Vitor",
                Email = "vvvvv@vasd.com",
                DataNascimento = new DateTime(1996, 03, 25),
                Avaliacao = 5,
                Ativo = true
            };

            Db.Alunos.Add(aluno);
            Db.SaveChanges();

            return View();
        }
    }
}
