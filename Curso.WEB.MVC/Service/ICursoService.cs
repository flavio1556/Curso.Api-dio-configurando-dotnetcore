using Curso.WEB.MVC.Models.Curso;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WEB.MVC.Service
{
    public interface ICursoService
    {
        [Post("/api/v1/Curso")]
        [Headers("Authorization: Bearer")]
        Task<CadastrarCursoViewModelOutput> Cadastrar(CadastrarCursoViewModelInput modelInput);

        [Get("/api/v1/Curso/Get{id}")]
        [Headers("Authorization: Bearer")]
        Task<IEnumerable<ListarCursoViewModelOutput>> Listar([AliasAs("id")] int id);

    }
}
