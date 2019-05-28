using MediatR;
using ProinterV.Domain.Events.Arquivo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.EventHandler
{
    public class ArquivoEventHandler : INotificationHandler<ArquivoPostadoEvent>
    {
        public Task Handle(ArquivoPostadoEvent notification, CancellationToken cancellationToken)
        {
            //Todo: Implementar a chamada ao serviço de push Notification
            return Task.CompletedTask;
        }
    }
}
