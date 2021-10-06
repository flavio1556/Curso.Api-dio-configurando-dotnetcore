using Curso.Api.Business.Entities;
using Curso.Api.Business.Repository;
using Curso.Api.Configurations;
using Curso.Api.Filters;
using Curso.Api.Models;
using Curso.Api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace Curso.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutheticationService _autheticationService;
        public UsuarioController(IUsuarioRepository usuarioRepository,  IAutheticationService autheticationService)
        {
            _usuarioRepository = usuarioRepository;
            _autheticationService = autheticationService;
        }
        /// <summary>
        ///  login
        /// </summary>
        /// <param name="loginViewModelsInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode:200,Description ="Sucesso ao autenticar", Type = typeof(LoginViewModelOutput))]
        [SwaggerResponse(statusCode: 400, Description = "Campos Obrigatorios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, Description = "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult logar(LoginViewModelsInput loginViewModelsInput)
        {
            Usuario usuario = _usuarioRepository.ObterUsuario(loginViewModelsInput);
            if(usuario == null)
            {
                return BadRequest("Houve um erro ao tentar Acessar");
            }
            var UsuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = usuario.Login,
                Email = usuario.Email
            };
          
            var token = _autheticationService.GerarToken(UsuarioViewModelOutput);
            return Ok(new LoginViewModelOutput()
            {
                Token = token,
                Usuario = UsuarioViewModelOutput
            });
        }
        /// <summary>
        ///  registro
        /// </summary>
        /// <param name="registroViewModelsInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, Description = "Sucesso ao autenticar", Type = typeof(RegistroViewModelsInput))]
        [SwaggerResponse(statusCode: 400, Description = "Campos Obrigatorios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, Description = "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("Registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelsInput registroViewModelsInput)
        {
                     
            var usuario = new Usuario();
            usuario.Login = registroViewModelsInput.Login;
            usuario.Email = registroViewModelsInput.Email;
            usuario.Senha = registroViewModelsInput.Senha;
          
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();
           
            return Created("", registroViewModelsInput);
        }
    }
}
