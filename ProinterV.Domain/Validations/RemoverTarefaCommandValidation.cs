using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public class RemoverTarefaCommandValidation : TarefaValidation<RemoverTarefaCommand>
    {
        public RemoverTarefaCommandValidation()
        {
            //ValidarIdGrupo();
            //ValidarNome();
        }
    }
}
