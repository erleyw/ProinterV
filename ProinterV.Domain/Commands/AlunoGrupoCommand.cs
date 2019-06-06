using ProinterV.Domain.Core.Commands;
using System;

namespace ProinterV.Domain.Commands
{
    public abstract class AlunoGrupoCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid IdAluno { get; protected set; }

        public Guid IdGrupo { get; protected set; }
    }
}