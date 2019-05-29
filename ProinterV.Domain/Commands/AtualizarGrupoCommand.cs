using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class AtualizarGrupoCommand : GrupoCommand
    {
        public AtualizarGrupoCommand(Guid idAluno, string nome, string descricao)
        {
            Nome = nome;
            IdAluno = idAluno;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
