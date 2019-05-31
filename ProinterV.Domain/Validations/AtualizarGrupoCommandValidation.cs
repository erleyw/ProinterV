using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public class AtualizarGrupoCommandValidation : GrupoValidation<AtualizarGrupoCommand>
    {
        public AtualizarGrupoCommandValidation()
        {
            ValidarNome();
            ValidarIdAluno();
            ValidarPrazo();
        }
    }
}
