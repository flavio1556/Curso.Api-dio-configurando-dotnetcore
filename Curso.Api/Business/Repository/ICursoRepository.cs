using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Business.Repository
{
    public interface ICursoRepository
    {
        void Adicionar(Entities.Curso curso);
        void Commit();
        List<Entities.Curso> ObterPorCodigoUsuario(int Codigo);
    }
}
