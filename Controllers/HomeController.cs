using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Security.Cryptography;
using at03.Models;

namespace at03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ViewBag.logado = Dados.logado;
        }

        public IActionResult Index()
        {
            ViewBag.logado = Dados.logado;
            List<Noticia> noticias = Dados.listarNoticias();
            return View(noticias);
        }

        public IActionResult Editais()
        {
            ViewBag.logado = Dados.logado;
            List<Edital> editais = Dados.listarEditais();
            return View(editais);
        }

        public IActionResult Contato()
        {
            ViewBag.logado = Dados.logado;
            return View();
        }

        public IActionResult Anuncie()
        {
            ViewBag.logado = Dados.logado;
            return View();
        }

        public IActionResult CadastraEdital()
        {
            if(!Dados.logado) return RedirectToAction("Index");
            ViewBag.logado = Dados.logado;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraEdital(Edital modelo)
        {
            if(!Dados.logado) return RedirectToAction("Index");
            ViewBag.logado = Dados.logado;
            if(ModelState.IsValid)
            {
                Dados.incluirEdital(modelo);
                return RedirectToAction("Editais");
            }
            return View();
        }

        public IActionResult CadastraNoticia()
        {
            if(!Dados.logado) return RedirectToAction("Index");
            ViewBag.logado = Dados.logado;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraNoticia(Noticia modelo)
        {
            if(!Dados.logado) return RedirectToAction("Index");
            ViewBag.logado = Dados.logado;
            if(ModelState.IsValid)
            {
                Dados.incluirNoticia(modelo);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.logado = Dados.logado;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario modelo)
        {
            ViewBag.logado = Dados.logado;
            if(ModelState.IsValid)
            {
                Usuario admin = Dados.retornarUsuario();
                
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] senha_utf8 = new UTF8Encoding().GetBytes(modelo.senha);
                    byte[] hash = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(senha_utf8);
                    string senha_md5 = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                    if (String.Equals(senha_md5,admin.senha)&&String.Equals(modelo.usuario,admin.usuario))
                    {
                        Dados.Login();
                        return RedirectToAction("Index");
                    } 
                }
            }
            return View();
        }

        public IActionResult Logoff()
        {
            ViewBag.logado = Dados.logado;
            Dados.Logoff();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.logado = Dados.logado;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
