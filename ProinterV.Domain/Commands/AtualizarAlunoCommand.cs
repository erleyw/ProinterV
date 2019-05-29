using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class AtualizarAlunoCommand : AlunoCommand
    {
        public AtualizarAlunoCommand(Guid id, string idUsuario, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
            IdUsuario = idUsuario;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarAlunoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
