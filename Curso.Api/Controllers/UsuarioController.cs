using Curso.Api.Filters;
using Curso.Api.Models;
using Curso.Api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        ///  login
        /// </summary>
        /// <param name="loginViewModelsInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode:200,Description ="Sucesso ao autenticar", Type = typeof(LoginViewModelsInput))]
        [SwaggerResponse(statusCode: 400, Description = "Campos Obrigatorios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, Description = "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult logar(LoginViewModelsInput loginViewModelsInput)
        {
            var UsuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "teste",
                Email = "Teste@hotmail.com"
            };
            var secret = Encoding.ASCII.GetBytes("testeapisenhafraca");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, UsuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, UsuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, UsuarioViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)

            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDesciptor);
            var token =  jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new 
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
            return Created("", registroViewModelsInput);
        }
    }
}
