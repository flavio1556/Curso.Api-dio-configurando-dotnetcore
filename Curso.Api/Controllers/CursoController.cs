using Curso.Api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Curso.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        /// <summary>
        /// Criacao de curso
        /// </summary>
        /// <param name="cursoViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 201, Description = "Sucesso ao autenticar")]
        [SwaggerResponse(statusCode: 401, Description = "Não autorizado")]
        [HttpPost]
        [Route("Created")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var codigoDoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("",cursoViewModelInput);
        }
    
        [SwaggerResponse(statusCode: 200, Description = "Sucesso ao autenticar")]
        [SwaggerResponse(statusCode: 400, Description = "Não autorizado")]
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            //var codigoDoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var Cursos = new List<CursoViewModelOutput>();
            Cursos.Add(new CursoViewModelOutput()
            {
                Codigo = 1,
                Descricao = "teste",
                Nome = "teste"
            });
            return Ok(Cursos);
        }
    }
}
