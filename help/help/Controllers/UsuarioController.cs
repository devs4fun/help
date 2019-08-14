using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            Usuario user = new Usuario() {
                Nome = "Robson",
                Sobrenome = "Junior",
                Email = "robson@mail.com",
                Senha = "123456789",
                RepeteSenha = "123456789"
            };
            
            _usuarioRepository.Salvar(user);
            string informacao = _usuarioRepository.getInformacao();
            return View(informacao as object);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

    }
}