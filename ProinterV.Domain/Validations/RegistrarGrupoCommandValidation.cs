using ProinterV.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Validations
{
    public class RegistrarGrupoCommandValidation : GrupoValidation<RegistrarGrupoCommand>
    {
        public RegistrarGrupoCommandValidation()
        {
            ValidarNome();
            ValidarIdAluno();
            ValidarPrazo();
        }
    }
}
