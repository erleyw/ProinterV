using ProinterV.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Events.Aluno
{
    public class AlunoRemovidoEvent : Event
    {
        public AlunoRemovidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
