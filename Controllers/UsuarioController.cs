using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testeTargetAPI.Models.Usuario;

namespace testeTargetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioContext _usuarioContext;
        private IUsuarioRepository usuarioRepository;

        public UsuarioController(UsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
            usuarioRepository = new UsuarioRepository(_usuarioContext);
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var result = usuarioRepository.buscarTodosUsuarios();
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { codigoRetorno = 500, message = "Não foi possível retornar os usuarios!" });
            }

        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {

            try
            {
                var result = usuarioRepository.adicionarUsuario(usuario);
                return StatusCode(result.codigoRetorno, result);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { codigoRetorno = 500, message = "Não foi possível realizar o cadastro!" });
            }

        }

        [HttpPut]
        public IActionResult Put(Usuario usuario)
        {
            
            try
            {
                var result = usuarioRepository.atualizarUsuario(usuario);
                return StatusCode(result.codigoRetorno, result);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { codigoRetorno = 500, message = "Não foi possível realizar o cadastro!" });
            }

        }

        [HttpDelete]
        public IActionResult Delete(int idUsuarioADeletar)
        {
           
            try
            {
                var result = usuarioRepository.deletarUsuario(idUsuarioADeletar);
                return StatusCode(result.codigoRetorno, result);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { codigoRetorno = 500, message = "Não foi possível realizar o cadastro!" });
            }

        }

    }
}
