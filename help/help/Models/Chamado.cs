using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace help.Models
{
    [Table("Chamados")]
    public class Chamado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Categoria { get; set; }
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set;}
        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public string Comentario { get; set; }
        [Required]
        public DateTime DataDeAbertura { get; set; }
        public DateTime DataDeFechamento { get; set; }
        public Usuario Usuario { get; set; }
    }
}