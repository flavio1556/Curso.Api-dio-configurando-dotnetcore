using Curso.Api.Business.Entities;
using Curso.Api.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Business.Repository
{
   public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(LoginViewModelsInput loginViewModelsInput);
    }
}
