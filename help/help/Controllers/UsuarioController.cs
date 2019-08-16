using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        user.EnviarEmailDeConfirmacao();
                    }
                }

            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Ativa(string token)
        {
            _usuarioRepository.AtivarUsuario(token);
            //agora eu preciso pegar essa token e comparar com todos os email do banco mas antes de 
            //cada comparação com o email, preciso encripitografar todos emails em cada comparação

            return View("index");
        }

    }
}