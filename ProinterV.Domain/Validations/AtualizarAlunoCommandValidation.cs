using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public class AtualizarAlunoCommandValidation : AlunoValidation<AtualizarAlunoCommand>
    {
        public AtualizarAlunoCommandValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarSenha();
            ValidarLogin();
        }
    }
}
