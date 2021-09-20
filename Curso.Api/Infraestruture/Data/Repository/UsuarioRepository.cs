using Curso.Api.Business.Entities;
using Curso.Api.Business.Repository;
using Curso.Api.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Infraestruture.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _contexto;
        public UsuarioRepository(CursoDbContext context)
        {
            _contexto = context;
        }
        public void Adicionar(Usuario usuario)
        {
            _contexto.usuarios.Add(usuario);
          
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public Usuario ObterUsuario(LoginViewModelsInput loginViewModelsInput)
        {

         return  _contexto.usuarios.FirstOrDefault(u => u.Login == loginViewModelsInput.Login && u.Senha == loginViewModelsInput.Senha);
        }
    }
}
