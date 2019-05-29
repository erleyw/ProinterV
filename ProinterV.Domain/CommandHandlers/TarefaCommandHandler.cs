using MediatR;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
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
        private readonly ITarefaRepository _alunoRepository;
        private readonly IMediatorHandler Bus;

        public TarefaCommandHandler(ITarefaRepository tarefaRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _alunoRepository = tarefaRepository;
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

            var aluno = new Tarefa(Guid.NewGuid, message.IdAluno, message., message.);

            if (_alunoRepository.GetById(aluno.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um aluno com esse Email."));
                return Task.FromResult(false);
            }

            _alunoRepository.Add(aluno);

            if (Commit())
            {
                Bus.RaiseEvent(new AlunoRegistradoEvent(aluno.Id, aluno.IdUsuario, aluno.Nome, aluno.Matricula));
            }

            return Task.FromResult(true);
        }
    }
}
