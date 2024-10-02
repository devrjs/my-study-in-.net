﻿using Microsoft.AspNetCore.Mvc;

namespace PrimeiraAppMVC.Controllers
{
    [Route("/", Order = 0)]
    [Route("minha-conta", Order = 1)]
    [Route("gestao-da-conta", Order = 2)]
    public class TestesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("detalhes/{id:int}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet("novo")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost("excluir/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
