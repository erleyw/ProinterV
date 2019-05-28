using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public class RegistrarNovoAlunoCommandValidation : AlunoValidation<RegistrarNovoAlunoCommand>
    {
        public RegistrarNovoAlunoCommandValidation()
        {
            ValidarNome();
            ValidarSenha();
            ValidarLogin();
        }
    }
}
