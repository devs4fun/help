using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace help.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private HelpDbContext _context;

        public UsuarioRepository(HelpDbContext helpDbContext)
        {
            _context = helpDbContext;
        }

        public string getInformacao()
        {
            return "Funcionou!";
        }

        public void Salvar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}