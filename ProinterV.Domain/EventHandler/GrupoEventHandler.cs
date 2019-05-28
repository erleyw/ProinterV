using MediatR;
using ProinterV.Domain.Events.Grupo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.EventHandler
{
    public class GrupoEventHandler : INotificationHandler<GrupoRegistradoEvent>
    {
        public Task Handle(GrupoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
