using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;

namespace ProinterV.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ApiController
    {
        public readonly ITarefaAppService _tarefaAppService;

        public TarefaController(
            ITarefaAppService tarefaAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _tarefaAppService = tarefaAppService;
        }

        [HttpPost("/tarefa")]
        [AllowAnonymous]
        public IActionResult Post(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(tarefaViewModel);
            }

            _tarefaAppService.Registrar(tarefaViewModel);

            return Response(tarefaViewModel);
        }

        [HttpPost("/tarefa/{idTarefa}/arquivo")]
        [AllowAnonymous]
        public IActionResult PostFile(Guid idTarefa, ArquivoTarefaViewModel arquivoTarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(arquivoTarefaViewModel);
            }

            _tarefaAppService.PostarArquivo(idTarefa, arquivoTarefaViewModel);

            return Response(arquivoTarefaViewModel);
        }
    }
}