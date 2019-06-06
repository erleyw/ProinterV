using MediatR;
using ProinterV.Domain.Events.Grupo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.EventHandler
{
    public class GrupoEventHandler : INotificationHandler<GrupoRegistradoEvent>, INotificationHandler<GrupoAtualizadoEvent>, INotificationHandler<GrupoRemovidoEvent>, INotificationHandler<AlunoIncluidoNoGrupoEvent>
    {
        public Task Handle(GrupoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(GrupoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(GrupoRemovidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(AlunoIncluidoNoGrupoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
