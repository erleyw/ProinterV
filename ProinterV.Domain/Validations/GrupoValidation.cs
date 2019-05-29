using FluentValidation;
using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public abstract class GrupoValidation<T> : AbstractValidator<T> where T : GrupoCommand
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor preencha o campo Nome")
                .Length(2, 100).WithMessage("O campo Nome deve ter entre 2 a 100 caracteres");
        }

        protected void ValidarPrazo()
        {
            RuleFor(c => c.Prazo)
                .NotEmpty().WithMessage("Por favor preencha o campo Prazo");
        }

        protected void ValidarIdAluno()
        {
            RuleFor(c => c.IdAluno)
                .NotEmpty().WithMessage("Por favor preencha o campo IdAluno");
        }
    }
}
