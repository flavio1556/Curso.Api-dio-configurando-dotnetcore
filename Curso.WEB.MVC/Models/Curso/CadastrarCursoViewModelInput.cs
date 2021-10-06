using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WEB.MVC.Models.Curso
{
    public class CadastrarCursoViewModelInput
    {
        [Display(Name = "Informe Nome do Curso")]
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Nome { get; set; }
        [Display(Name = "Informe a descricao do Curso")]
        [Required(ErrorMessage = "Descricao é obrigatorio")]
        public string Descricao { get; set; }
    }
}
