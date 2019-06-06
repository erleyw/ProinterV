using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProinterV.Application.ViewModels
{
    public class AlunoGrupoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O IdGrupo é obrigatório")]
        [DisplayName("Cod Grupo")]
        public Guid IdGrupo { get; set; }

        [DisplayName("Cod Aluno")]
        public Guid? IdAluno { get; set; }

        [DisplayName("Email do Aluno")]
        public string EmailAluno { get; set; }
    }
}
