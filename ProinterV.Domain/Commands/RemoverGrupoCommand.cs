using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class RemoverGrupoCommand : GrupoCommand
    {
        public RemoverGrupoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverGrupoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
