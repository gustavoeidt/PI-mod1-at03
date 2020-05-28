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
using System.Net.Mail;

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
            NoticiaRepository noticiaRep = new NoticiaRepository();
            List<Noticia> noticias = noticiaRep.Lista();
            return View(noticias);
        }

        public IActionResult Editais()
        {
            ViewBag.logado = Dados.logado;
            EditalRepository editalRep = new EditalRepository();
            List<Edital> editais = editalRep.Lista();
            return View(editais);
        }

        public IActionResult Contato()
        {
            ViewBag.logado = Dados.logado;
            return View();
        }

        [HttpPost]
        public IActionResult Contato( Contato c)
        {
            ViewBag.logado = Dados.logado;
            if(ModelState.IsValid)
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add("infocon@infocon.com.br");
                mailMessage.From = new MailAddress(c.email);
                mailMessage.Subject = c.nome;
                mailMessage.Body = c.assunto;
                SmtpClient smtpClient = new SmtpClient("smtp.your-isp.com");
                smtpClient.Send(mailMessage);

                return RedirectToAction("Index");
            }
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
                EditalRepository editalRep = new EditalRepository();
                editalRep.Cadastra(modelo, Dados.usuario);
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
                NoticiaRepository noticiaRep = new NoticiaRepository();
                noticiaRep.Cadastra(modelo,Dados.usuario);
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
                UsuarioRepository usrRep = new UsuarioRepository();
                Usuario admin = usrRep.Lista(1);
                
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] senha_utf8 = new UTF8Encoding().GetBytes(modelo.senha);
                    byte[] hash = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(senha_utf8);
                    string senha_md5 = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                    if (String.Equals(senha_md5,admin.senha)&&String.Equals(modelo.usuario,admin.usuario))
                    {
                        Dados.Login();
                        Dados.usuario = admin;
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
