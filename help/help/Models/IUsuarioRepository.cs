using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace help.Models
{
    public interface IUsuarioRepository
    {
        void Salvar(Usuario usuario);
        string getInformacao();
        Usuario BuscarPorEmail(Usuario usuario);
    }
}
