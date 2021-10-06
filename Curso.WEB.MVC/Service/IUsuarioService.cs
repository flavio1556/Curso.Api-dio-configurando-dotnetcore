using Curso.WEB.MVC.Models.Usuario;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WEB.MVC.Service
{
  public  interface IUsuarioService
    {
        [Post("/api/v1/Usuario/Registrar")]
        Task<CadastrarUsuarioViewModelOutput> Cadastrar(CadastrarUsuarioViewModelInput modelInput);

        [Post("/api/v1/Usuario/logar")]
        Task<LoginUsuarioViewModelOutput> Login(LoginUsuarioViewModelInput modelInput);
    }
}
