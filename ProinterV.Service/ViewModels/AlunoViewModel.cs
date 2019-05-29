using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProinterV.Application.ViewModels
{
    public class AlunoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Matrícula")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O IdUsuario é obrigatório")]
        [DisplayName("Cod Usuário")]
        public string IdUsuario { get; set; }
    }
}
