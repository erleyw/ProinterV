using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class RegistrarTarefaCommand : TarefaCommand
    {
        public RegistrarTarefaCommand(string nome, string descricao, Guid idAluno, Guid idGrupo)
        {
            Nome = nome;
            Descricao = descricao;
            IdAluno = idAluno;
            IdGrupo = idGrupo;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarNovoAlunoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
