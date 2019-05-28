using MediatR;
using ProinterV.Domain.Events.Aluno;
using System.Threading;
using System.Threading.Tasks;

namespace ProinterV.Domain.EventHandler
{
    public class AlunoEventHandler :
        INotificationHandler<AlunoRegistradoEvent>,
        INotificationHandler<AlunoAtualizadoEvent>,
        INotificationHandler<AlunoRemovidoEvent>
    {
        public Task Handle(AlunoAtualizadoEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(AlunoRegistradoEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(AlunoRemovidoEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
