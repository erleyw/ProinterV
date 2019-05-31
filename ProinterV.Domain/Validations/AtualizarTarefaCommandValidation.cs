using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public class AtualizarTarefaCommandValidation : TarefaValidation<AtualizarTarefaCommand>
    {
        public AtualizarTarefaCommandValidation()
        {
            ValidarNome();
            ValidarIdGrupo();
        }
    }
}
