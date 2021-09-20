using Curso.Api.Business.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Infraestruture.Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _contexto;
        public CursoRepository(CursoDbContext context)
        {
            _contexto = context;
        }
        public void Adicionar(Business.Entities.Curso curso)
        {
            _contexto.Cursos.Add(curso);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public List<Business.Entities.Curso> ObterPorCodigoUsuario(int Codigo)
        {
           return _contexto.Cursos.Include(i => i.Usuario).Where(c => c.CodigoUsuario == Codigo).ToList();
        }
    }
}
