using ProinterV.Domain.Core.Events;
using System;

namespace ProinterV.Domain.Events.Grupo
{
    public class GrupoRemovidoEvent : Event
    {
        public GrupoRemovidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
