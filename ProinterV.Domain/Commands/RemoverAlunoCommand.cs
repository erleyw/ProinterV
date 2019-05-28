using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class RemoverAlunoCommand : AlunoCommand
    {
        public RemoverAlunoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverAlunoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
