using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testeTargetAPI.Models.Usuario
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> buscarTodosUsuarios();
        dynamic adicionarUsuario(Usuario usuario);
        dynamic atualizarUsuario(Usuario usuario);
        dynamic deletarUsuario(int idUsuarioADeletar);
    }
}
