using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Api.Models;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;

namespace ProinterV.Api.Controllers
{
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

        [Authorize("Bearer")]
        [HttpPost("tarefa")]
        [ProducesResponseType(typeof(ResponseBase<TarefaViewModel>), 200)]
        public IActionResult RegistrarTarefa(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<TarefaViewModel>(tarefaViewModel);
            }

            _tarefaAppService.Register(tarefaViewModel);

            return Response<TarefaViewModel>(tarefaViewModel);
        }

        [Authorize("Bearer")]
        [HttpPut("/tarefa")]
        [ProducesResponseType(typeof(ResponseBase<TarefaViewModel>), 200)]
        public IActionResult AlterarTarefa(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<TarefaViewModel>(tarefaViewModel);
            }

            _tarefaAppService.Update(tarefaViewModel);

            return Response<TarefaViewModel>(tarefaViewModel);
        }

        [Authorize("Bearer")]
        [HttpGet("/tarefa")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<TarefaViewModel>>), 200)]
        public IActionResult BuscarTodasTarefas()
        {
            return Response<IEnumerable<TarefaViewModel>>(_tarefaAppService.GetAll());
        }

        [Authorize(Policy = "CanRemoveCustomerData")]
        [HttpGet("tarefa/{idTarefa}")]
        [ProducesResponseType(typeof(ResponseBase<TarefaViewModel>), 200)]
        public IActionResult GetTarefaById(Guid idTarefa)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<TarefaViewModel>(idTarefa);
            }

            var tarefa = _tarefaAppService.GetById(idTarefa);

            return Response<TarefaViewModel>(tarefa);
        }

        [Authorize(Policy = "Bearer")]
        [HttpPost("/tarefa/{idTarefa}/arquivo")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<TarefaViewModel>>), 200)]
        public IActionResult PostFile(Guid idTarefa, [FromBody] ArquivoTarefaViewModel arquivoTarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<ArquivoTarefaViewModel>(arquivoTarefaViewModel);
            }

            _tarefaAppService.PostarArquivo(idTarefa, arquivoTarefaViewModel);

            return Response<ArquivoTarefaViewModel>(arquivoTarefaViewModel);
        }

        [Authorize(Policy = "Bearer")]
        [HttpDelete("tarefa")]
        [ProducesResponseType(typeof(ResponseBase<TarefaViewModel>), 200)]
        public IActionResult ExcluirTarefa(Guid id)
        {
            _tarefaAppService.Remove(id);

            return Response<TarefaViewModel>();
        }

        [ProducesResponseType(typeof(IEnumerable<TarefaHistoryData>), 200)]
        [HttpGet("tarefa/history/{id:guid}")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<TarefaHistoryData>>), 200)]
        public IActionResult HistoricoDaTarefa(Guid id)
        {
            var tarefaHistoryData = _tarefaAppService.GetAllHistory(id);
            return Response<IEnumerable<TarefaHistoryData>>(tarefaHistoryData);
        }
    }
}