using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace help.Models
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Usuario BuscarPorEmail(Usuario usuario);
        Usuario BuscarPorId(int id);
        void AtivarUsuario(string token);
    }
}
