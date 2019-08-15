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
                RepeteSenha = userViewModel.repeteSenha
            };

            Usuario userBuscadoNoBanco = _usuarioRepository.BuscarPorEmail(user);

            if (user.ehValido())
            {
                if (user.Email != userBuscadoNoBanco.Email)
                {
                    _usuarioRepository.Salvar(user);
                }
               
            }

            return View("Index");
        }

    }
}