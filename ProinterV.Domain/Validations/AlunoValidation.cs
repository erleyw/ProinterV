using FluentValidation;
using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public abstract class AlunoValidation<T> : AbstractValidator<T> where T : AlunoCommand
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor preencha o campo Nome")
                .Length(2, 100).WithMessage("O campo Nome deve ter entre 2 a 100 caracteres");
        }

        protected void ValidarIdUsuario()
        {
            RuleFor(c => c.IdUsuario)
                .NotEmpty().WithMessage("Por favor preencha o campo IdUsuario");
        }

        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
