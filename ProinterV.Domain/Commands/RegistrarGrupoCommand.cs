using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class RegistrarGrupoCommand : GrupoCommand
    {
        public RegistrarGrupoCommand(string nome, string descricao, Guid idAluno, DateTime prazo, string materialDeApoio)
        {
            Nome = nome;
            Descricao = descricao;
            IdAluno = idAluno;
            Nome = nome;
            Prazo = prazo;
            MaterialApoio = materialDeApoio;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
