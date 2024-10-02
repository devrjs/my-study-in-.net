using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers
{
    public class PessoasController : Controller
    {
        private readonly AppDbContext _context;

        public PessoasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.pessoas.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }

            var pessoa = await _context.pessoas.FirstOrDefaultAsync(pessoa => pessoa.Id == id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (_context.pessoas == null)
            {
                return NotFound();
            }

            var aluno = await _context.pessoas.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.pessoas.Any(pessoa => pessoa.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var pessoa = await _context.pessoas.FindAsync(id);

            if (pessoa != null)
            {
                _context.pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
