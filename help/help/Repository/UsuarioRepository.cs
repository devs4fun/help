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
        public void Salvar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}