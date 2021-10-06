using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WEB.MVC.Models.Usuario
{
    public class LoginUsuarioViewModelOutput
    {
        public string Token { get; set; }
        public Usuarios Usuario { get; set; }

        public class Usuarios
        {
            public int Codigo { get; set; }
            public string Login { get; set; }
            public string Email { get; set; }
        }
    }
}
