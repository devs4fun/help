using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace help.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string RepeteSenha { get; set; }


        public bool ehValido()
        {
            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Sobrenome) || string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Senha) || string.IsNullOrWhiteSpace(RepeteSenha) || Nome.Any(x => char.IsDigit(x)) || 
                Sobrenome.Any(x => char.IsDigit(x)) || Senha.Length < 8 || Senha != RepeteSenha)
            {
                return false;

            } else
            {
                return true;
            }
        }
    }
}