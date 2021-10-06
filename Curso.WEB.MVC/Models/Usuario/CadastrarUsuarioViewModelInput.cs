using System.ComponentModel.DataAnnotations;

namespace Curso.WEB.MVC.Models.Usuario
{
    public class CadastrarUsuarioViewModelInput
    {
        [Required(ErrorMessage = "Login é obrigatorio")]
        [Display(Name = "Login do Usuário")]
        public string Login { get; set; }
        [Display(Name = "Email do Usuário")]
        [Required(ErrorMessage = "Email é obrigatorio")]
        [EmailAddress(ErrorMessage ="Email em formato em Invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatorio")]
        [Display(Name = "Informe a Senha")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Senha Deve conter no minimo 4 digite e no maximo 10")]
        public string Senha { get; set; }
    }
}
