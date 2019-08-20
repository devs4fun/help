using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace help.Controllers
{
    public class HomeController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public HomeController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string senha)
        {
            var user = new Usuario();
            _usuarioRepository.BuscarPorEmail(user);

            if(user == null)
            {
                return View();
            }

            if (user.Email != email || user.Senha != senha)
            {
                return View();
            }
            else
            {
                if(user.Admin == true)
                {

                }
                else
                {

                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}