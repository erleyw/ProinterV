using MediatR;
using ProinterV.Domain.Events.Tarefa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.EventHandler
{
    public class TarefaEventHandler : INotificationHandler<TarefaRegistradaEvent>
    {
        public Task Handle(TarefaRegistradaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
