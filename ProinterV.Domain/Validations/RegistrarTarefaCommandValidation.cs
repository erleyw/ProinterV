using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public class RegistrarTarefaCommandValidation : TarefaValidation<RegistrarTarefaCommand>
    {
        public RegistrarTarefaCommandValidation()
        {
            ValidarNome();
            ValidarIdGrupo();
        }
    }
}
