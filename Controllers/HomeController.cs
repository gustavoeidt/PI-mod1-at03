using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using at03.Models;

namespace at03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Noticia> noticias = Dados.listarNoticias();
            return View(noticias);
        }

        public IActionResult Editais()
        {
            List<Edital> editais = Dados.listarEditais();
            return View(editais);
        }

        public IActionResult CadastraEdital()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraEdital(Edital modelo)
        {
            if(ModelState.IsValid)
            {
                Dados.incluirEdital(modelo);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult CadastraNoticia()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraNoticia(Noticia modelo)
        {
            if(ModelState.IsValid)
            {
                Dados.incluirNoticia(modelo);
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
