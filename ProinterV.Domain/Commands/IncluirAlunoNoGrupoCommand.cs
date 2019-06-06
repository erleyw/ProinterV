using ProinterV.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Commands
{
    public class IncluirAlunoNoGrupoCommand : AlunoGrupoCommand
    {
        public IncluirAlunoNoGrupoCommand(Guid idAluno, Guid idGrupo)
        {
            IdAluno = idAluno;
            IdGrupo = idGrupo;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
