using MediatR;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using ProinterV.Domain.Events.Aluno;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.CommandHandlers
{
    public class AlunoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarAlunoCommand, bool>,
        IRequestHandler<AtualizarAlunoCommand, bool>,
        IRequestHandler<RemoverAlunoCommand, bool>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediatorHandler Bus;

        public AlunoCommandHandler(IAlunoRepository alunoRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _alunoRepository = alunoRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegistrarAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var aluno = new Aluno(Guid.NewGuid(), message.IdUsuario, message.Nome, message.Matricula);

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

        public Task<bool> Handle(AtualizarAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var aluno = new Aluno(message.Id, message.IdUsuario, message.Nome, message.Matricula);
            var existeAluno = _alunoRepository.GetById(aluno.Id);

            if (existeAluno != null && existeAluno.Id != aluno.Id)
            {
                if (!existeAluno.Equals(aluno))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Aluno não encontrado na base de dados."));
                    return Task.FromResult(false);
                }
            }

            _alunoRepository.Update(aluno);

            if (Commit())
            {
                Bus.RaiseEvent(new AlunoAtualizadoEvent(aluno.Id, aluno.IdUsuario, aluno.Nome, aluno.Matricula));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoverAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _alunoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new AlunoRemovidoEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _alunoRepository.Dispose();
        }
    }
}
