using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class AtualizarAlunoCommand : AlunoCommand
    {
        public AtualizarAlunoCommand(Guid id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarAlunoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
