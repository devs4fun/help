using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace help.Models
{
    public class ChamadoViewModel
    {
        public int categoria { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime dataDeAbertura { get; set; }
        public string nomeDoUsuario { get; set; }
    }
}