using Curso.Api.Business.Repository;
using Curso.Api.Configurations;
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
        private readonly ICursoRepository _cursoRepository;
        private readonly IAutheticationService _autheticationService;
        public CursoController(ICursoRepository cursoRepository, IAutheticationService autheticationService)
        {
            _cursoRepository = cursoRepository;
            _autheticationService = autheticationService;
        }
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
            Business.Entities.Curso curso = new Business.Entities.Curso
            {
                CodigoUsuario = codigoDoUsuario,
                Descricao = cursoViewModelInput.Descricao,
                Nome = cursoViewModelInput.Nome
            };
            _cursoRepository.Adicionar(curso);
            _cursoRepository.Commit();

            return Created("",cursoViewModelInput);
        }
    
        [SwaggerResponse(statusCode: 200, Description = "Sucesso ao autenticar")]
        [SwaggerResponse(statusCode: 400, Description = "Não autorizado")]
        [HttpGet]
        [Route("Get{id}")]
        public async Task<IActionResult> Get(int id)
        {
        //    var Cursos = new List<Business.Entities.Curso>();
            var Cursos = _cursoRepository.ObterPorCodigoUsuario(id)
                .Select(s => new CursoViewModelOutput()
                {
                    Nome = s.Nome,
                    Descricao = s.Descricao,
                    Login = s.Usuario.Login
                });
            if(Cursos.Count() == 0)
            {
                return NotFound();
            }
            return Ok(Cursos);
        }
    }
}
