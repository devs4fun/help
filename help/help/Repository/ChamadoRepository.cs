using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace help.Repository
{
    public class ChamadoRepository : IChamadoRepository
    {
        private HelpDbContext _context;

        public ChamadoRepository(HelpDbContext helpDbContext)
        {
            _context = helpDbContext;
        }

        public void AbrirChamado(Chamado chamado)
        {
            _context.Chamados.Add(chamado);
            _context.SaveChanges();
        }

        public void AtualizarChamado(Chamado chamado)
        {
            throw new NotImplementedException();
        }
    }
}