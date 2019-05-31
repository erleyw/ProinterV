using MediatR;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using ProinterV.Domain.Events.Tarefa;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.CommandHandlers
{
    public class TarefaCommandHandler : CommandHandler,
        IRequestHandler<RegistrarTarefaCommand, bool>,
        IRequestHandler<AtualizarTarefaCommand, bool>,
        IRequestHandler<RemoverTarefaCommand, bool>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMediatorHandler Bus;

        public TarefaCommandHandler(ITarefaRepository tarefaRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _tarefaRepository = tarefaRepository;
            Bus = bus;
        }

        public Task<bool> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(RemoverTarefaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(RegistrarTarefaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var tarefa = new Tarefa(Guid.NewGuid(), message.IdAluno, message.Nome, message.Descricao);

            if (_tarefaRepository.GetById(tarefa.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um aluno com esse Email."));
                return Task.FromResult(false);
            }

            _tarefaRepository.Add(tarefa);

            if (Commit())
            {
                Bus.RaiseEvent(new TarefaRegistradaEvent(tarefa.Id, tarefa.IdGrupo, tarefa.IdAluno, tarefa.Nome, tarefa.Descricao));
            }

            return Task.FromResult(true);
        }
    }
}
