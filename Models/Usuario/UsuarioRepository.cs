using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using testeTargetAPI.Models.Usuario;

namespace testeTargetAPI.Models.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _usuarioContext;

        public UsuarioRepository(UsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }

        dynamic IUsuarioRepository.adicionarUsuario(Usuario usuario)
        {
            try
            {
                
                _usuarioContext.Add<Usuario>(new Usuario() { nome = usuario.nome, email = usuario.email });
                _usuarioContext.SaveChanges();
                return new
                {
                    codigoRetorno = (int)HttpStatusCode.Created,
                    mensagem = "Cadatro realizado com sucesso!"
                };
            }
            catch (Exception genericException)
            {

                return new
                {
                    codigoRetorno = (int)HttpStatusCode.InternalServerError,
                    mensagem = genericException.Message
                };

            }
        }

        dynamic IUsuarioRepository.atualizarUsuario(Usuario usuario)
        {
            try
            {

                _usuarioContext.Update<Usuario>(usuario);
                _usuarioContext.SaveChanges();
                return new
                {
                    codigoRetorno = (int)HttpStatusCode.OK,
                    mensagem = "Cadatro atualizado com sucesso!"
                };
            }
            catch (Exception genericException)
            {
                return new
                {
                    codigoRetorno = (int)HttpStatusCode.InternalServerError,
                    mensagem = genericException.Message
                };
            }
        }

        IEnumerable<Usuario> IUsuarioRepository.buscarTodosUsuarios()
        {
            try
            {

                _usuarioContext.usuarios.ToList<Usuario>();
                _usuarioContext.SaveChanges();
                return _usuarioContext.usuarios.ToList<Usuario>();
            }
            catch (Exception genericException)
            {
                return Enumerable.Empty<Usuario>();
            }
        }


        dynamic IUsuarioRepository.deletarUsuario(int idUsuarioADeletar)
        {
            try
            {

                _usuarioContext.Remove<Usuario>(new Usuario() { id = idUsuarioADeletar });
                _usuarioContext.SaveChanges();
                return new
                {
                    codigoRetorno = (int)HttpStatusCode.OK,
                    mensagem = "Cadatro deletado com sucesso!"
                };
            }
            catch (Exception genericException)
            {
                return new
                {
                    codigoRetorno = (int)HttpStatusCode.InternalServerError,
                    mensagem = genericException.Message
                };
            }
        }
    }
}
