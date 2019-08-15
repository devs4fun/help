using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace help.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(100)]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(32)]
        public string Senha { get; set; }
        public bool Status { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public bool Admin { get; set; }


        public bool ehValido()
        {
            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Sobrenome) || string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Senha) ||Nome.Any(x => char.IsDigit(x)) || 
                Sobrenome.Any(x => char.IsDigit(x)) || Senha.Length < 8)
            {
                return false;

            } else
            {
                return true;
            }
        }

    }
}