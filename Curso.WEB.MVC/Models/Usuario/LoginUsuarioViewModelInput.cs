using System.ComponentModel.DataAnnotations;

namespace Curso.WEB.MVC.Models.Usuario
{
    public class LoginUsuarioViewModelInput
    {
        
        [Required(ErrorMessage = "Login é obrigatorio")]
        [Display(Name = "Login do Usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha é obrigatorio")]
        [Display(Name = "Informe a Senha")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Senha Deve conter no minimo 4 digite e no maximo 10")]
        public string Senha { get; set; }
    }
}
