﻿using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class RegistrarAlunoCommand : AlunoCommand
    {
        public RegistrarAlunoCommand(string nome, string idUsuario, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
            IdUsuario = idUsuario;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarNovoAlunoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
