using MediatR;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using ProinterV.Domain.Events.Aluno;
using ProinterV.Domain.Events.Grupo;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.CommandHandlers
{
    public class AlunoGrupoCommandHandler : CommandHandler,
        IRequestHandler<IncluirAlunoNoGrupoCommand, bool>
    {
        private readonly IAlunoGrupoRepository _alunoGrupoRepository;
        private readonly IMediatorHandler Bus;

        public AlunoGrupoCommandHandler(IAlunoGrupoRepository alunoRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _alunoGrupoRepository = alunoRepository;
            Bus = bus;
        }

        public Task<bool> Handle(IncluirAlunoNoGrupoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var alunoGrupo = new AlunoGrupo(Guid.NewGuid(), message.IdGrupo, message.IdAluno);

            if (_alunoGrupoRepository.GetByGrupo(alunoGrupo.IdAluno, alunoGrupo.IdGrupo) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um aluno com esse Email neste grupo."));
                return Task.FromResult(false);
            }

            _alunoGrupoRepository.Add(alunoGrupo);

            if (Commit())
            {
                Bus.RaiseEvent(new AlunoIncluidoNoGrupoEvent(alunoGrupo.Id, alunoGrupo.IdGrupo, alunoGrupo.IdAluno));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _alunoGrupoRepository.Dispose();
        }
    }
}
