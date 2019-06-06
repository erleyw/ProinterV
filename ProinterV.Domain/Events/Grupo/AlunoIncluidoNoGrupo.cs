using ProinterV.Domain.Core.Events;
using System;

namespace ProinterV.Domain.Events.Grupo
{
    public class AlunoIncluidoNoGrupoEvent : Event
    {
        public AlunoIncluidoNoGrupoEvent(Guid id, Guid idAluno, Guid idGrupo)
        {
            Id = id;
            IdAluno = idAluno;
            IdGrupo = idGrupo;
        }

        public Guid Id { get; set; }
        public Guid IdAluno { get; private set; }
        public Guid IdGrupo { get; private set; }
    }
}
