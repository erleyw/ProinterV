using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class RegistrarNovoAlunoCommand : AlunoCommand
    {
        public RegistrarNovoAlunoCommand(string nome, string login, string senha)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarNovoAlunoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
