using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace help.Models
{
    public interface IChamadoRepository
    {
        void AbrirChamado (Chamado chamado);
        void AtualizarChamado(Chamado chamado);
    }
}