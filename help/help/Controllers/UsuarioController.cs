using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
//using System.Web.Mail;
using System.Web.Mvc;

namespace help.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: Usuario
        [HttpGet]
        public ActionResult Index()
        {
            string informacao = _usuarioRepository.getInformacao();
            return View(informacao as object);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioViewModel userViewModel)
        {
            Usuario user = new Usuario()
            {
                Nome = userViewModel.nome,
                Sobrenome = userViewModel.sobreNome,
                Email = userViewModel.email,
                Senha = userViewModel.senha,
                Status = false,
                DataDeCadastro = DateTime.Now,
                Admin = false
                
            };

            Usuario VerificarSeUsuarioExiste = _usuarioRepository.BuscarPorEmail(user);

            if (VerificarSeUsuarioExiste == null)
            {
                if (user.Senha == userViewModel.repeteSenha)
                {
                    if (user.ehValido())
                    {
                         _usuarioRepository.Salvar(user);

                        MailMessage mm = new MailMessage("fernandesjunior1994@gmail.com", "robsonjunior1994@gmail.com");
                        mm.Subject = "Este email é de teste";
                        mm.Body = "Corpo do email de teste";
                        mm.IsBodyHtml = false;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        NetworkCredential nc = new NetworkCredential("fernandesjunior1994@gmail.com", "rb25817087");
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = nc;
                        smtp.Send(mm);

                        //Você deve também permitir o acesso "menos seguro" ao seu Gmail, 
                        //através da página Aplicativos menos seguros.
                        // link https://www.google.com/settings/security/lesssecureapps

                    }
                }

            }

            return View("Index");
        }

    }
}