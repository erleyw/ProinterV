using MediatR;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using ProinterV.Domain.Events.Grupo;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.CommandHandlers
{
    public class GrupoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarGrupoCommand, bool>,
        IRequestHandler<AtualizarGrupoCommand, bool>,
        IRequestHandler<RemoverGrupoCommand, bool>
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly IMediatorHandler Bus;

        public GrupoCommandHandler(IGrupoRepository grupoRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _grupoRepository = grupoRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegistrarGrupoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var grupo = new GrupoTrabalho(Guid.NewGuid(), message.IdAluno, message.Nome, message.Descricao, message.Prazo, message.MaterialApoio);

            _grupoRepository.Add(grupo);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoRegistradoEvent(grupo.Id, grupo.IdAluno, grupo.Nome, grupo.Descricao, grupo.Prazo, grupo.MaterialApoio));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AtualizarGrupoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var grupo = new GrupoTrabalho(message.Id, message.IdAluno, message.Nome, message.Descricao, message.Prazo, message.MaterialApoio);
            var existingGrupo = _grupoRepository.GetById(grupo.Id);

            if (existingGrupo != null && existingGrupo.Id != grupo.Id)
            {
                if (!existingGrupo.Equals(grupo))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Grupo não encontrado na base de dados."));
                    return Task.FromResult(false);
                }
            }

            _grupoRepository.Update(grupo);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoAtualizadoEvent(grupo.Id, grupo.IdAluno, grupo.Nome, grupo.Descricao, grupo.Prazo, grupo.MaterialApoio));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoverGrupoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _grupoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoRemovidoEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _grupoRepository.Dispose();
        }
    }
}
