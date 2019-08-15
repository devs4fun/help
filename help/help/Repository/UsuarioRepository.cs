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

        public Usuario BuscarPorEmail(Usuario user)
        {
            Usuario usuarioRetornado = _context.Usuarios.FirstOrDefault(u => u.Email == user.Email);
            return usuarioRetornado;
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