using Curso.WEB.MVC.Models.Curso;
using Curso.WEB.MVC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Curso.WEB.MVC.Controllers
{
   
    public class CursoController : Controller
    {

        private readonly ICursoService _cursoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CursoController(ICursoService cursoService, IHttpContextAccessor httpContextAccessor)
        {
            _cursoService = cursoService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Cadastrar()
        {

            return View();
        }        
        [HttpPost]
        public async  Task<IActionResult> Cadastrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput)
        {
            try
            {
                var curso = await _cursoService.Cadastrar(cadastrarCursoViewModelInput);
                ModelState.AddModelError("", $"Curso cadastrado {curso.Nome}");

            }
            catch(ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception e)
            {
                throw e;
            }
            return View();
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> Listar()
        {
     
            IEnumerable <ListarCursoViewModelOutput> curso = new List<ListarCursoViewModelOutput>();
            try
            {
                var Codigo = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
                curso = await _cursoService.Listar(Convert.ToInt32(Codigo));
               
                return View(curso);
            
            }
            catch(ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            //var curso = new List<ListarCursoViewModelOutput>();
            return View(curso);
        }
    }
}
