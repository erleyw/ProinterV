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
    public class GrupoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarGrupoCommand, bool>,
        IRequestHandler<AtualizarGrupoCommand, bool>,
        IRequestHandler<RemoverGrupoCommand, bool>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMediatorHandler Bus;

        public GrupoCommandHandler(ITarefaRepository tarefaRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _tarefaRepository = tarefaRepository;
            Bus = bus;
        }

        public Task<bool> Handle(AtualizarGrupoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(RemoverGrupoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(RegistrarGrupoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var grupo = new Tarefa(Guid.NewGuid(), message.IdAluno, message.Nome, message.Descricao);

            if (_tarefaRepository.GetById(grupo.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um grupo pra esse Aluno."));
                return Task.FromResult(false);
            }

            _tarefaRepository.Add(grupo);

            if (Commit())
            {
                Bus.RaiseEvent(new TarefaRegistradaEvent(grupo.Id, grupo.IdGrupo, grupo.IdAluno, grupo.Nome, grupo.Descricao));
            }

            return Task.FromResult(true);
        }
    }
}
