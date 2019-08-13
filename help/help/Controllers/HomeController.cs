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
        public ActionResult Index()
        {
            //HelpDbContext context = new HelpDbContext();
            //Usuario user = new Usuario();
            //user.Nome = "Robson";
            //user.Sobrenome = "Junior";
            //user.Email = "robsonjunior1994@gmail.com";
            //user.Senha = "123456789";
            //user.RepeteSenha = "123456789";

            //context.Usuarios.Add(user);
            //context.SaveChanges();
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