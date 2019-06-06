using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProinterV.Application.ViewModels
{
    class IncluirAlunoNoGrupoViewModel
    {

        [Required(ErrorMessage = "O IdGrupo é obrigatório")]
        [DisplayName("Cod Grupo")]
        public Guid IdGrupo { get; set; }

        [DisplayName("Email do Aluno")]
        public string EmailAluno { get; set; }
    }
}
