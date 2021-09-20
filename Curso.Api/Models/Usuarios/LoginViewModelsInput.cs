using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Models.Usuarios
{
    public class LoginViewModelsInput
    {
        [Required(ErrorMessage = "O login é obrigatorio")]
        public  string Login { get; set; }

        [Required(ErrorMessage = "O Senha é obrigatorio")]
        public string Senha { get; set; }
    }
}
