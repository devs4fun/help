using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace help.Controllers
{
    public class BoardController : Controller
    {
        private IChamadoRepository _chamadoRepository;
        private IUsuarioRepository _usuarioRepository;

        public BoardController(IChamadoRepository chamadoRepository,
            IUsuarioRepository usuarioRepository)
        {
            _chamadoRepository = chamadoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AbrirChamado(int id)
        {
            var user = _usuarioRepository.BuscarPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult AbrirChamado(ChamadoViewModel chamadoViewModel)
        {
            Chamado chamado = new Chamado()
            {
                Status = true,
                Categoria = chamadoViewModel.categoria,
                Titulo = chamadoViewModel.titulo,
                Descricao = chamadoViewModel.descricao,
                DataDeAbertura = DateTime.Now,
                DataDeFechamento = DateTime.Now.AddYears(5)
            };
            
            if(chamado == null || string.IsNullOrEmpty(chamadoViewModel.titulo) || string.IsNullOrEmpty(chamadoViewModel.descricao)
                || chamadoViewModel.dataDeAbertura == null)
            {
                return View();
            }
            else
            {
                if (chamadoViewModel.categoria <= 0)
                {
                    return View();
                }
                else
                {
                    _chamadoRepository.AbrirChamado(chamado);
                }
            }
            return View("Index");
        }
    }
}