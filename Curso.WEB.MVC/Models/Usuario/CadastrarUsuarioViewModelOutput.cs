using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WEB.MVC.Models.Usuario
{
    public class CadastrarUsuarioViewModelOutput
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
