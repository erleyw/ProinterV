using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Application.EventSourcedNormalizers;
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

        /// <summary>
        /// Registrar uma nova tarefa
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPost("/tarefa")]
        [AllowAnonymous]
        public IActionResult RegistrarTarefa(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<TarefaViewModel>(tarefaViewModel);
            }

            //_tarefaAppService.Register(tarefaViewModel);

            return Response<TarefaViewModel>(tarefaViewModel);
        }

        /// <summary>
        /// Alterar uma tarefa
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPut("/tarefa")]
        [AllowAnonymous]
        public IActionResult AlterarTarefa(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<TarefaViewModel>(tarefaViewModel);
            }

            //_tarefaAppService.Register(tarefaViewModel);

            return Response<TarefaViewModel>(tarefaViewModel);
        }

        /// <summary>
        /// Buscar todas as tarefas
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet("/tarefa")]
        [AllowAnonymous]
        public IActionResult BuscarTodasTarefas()
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                //return Response(tarefaViewModel);
            }

            //_tarefaAppService.Register(tarefaViewModel);

            return Response<IEnumerable<TarefaViewModel>>();
        }

        [HttpGet("tarefa/{idTarefa}")]
        [AllowAnonymous]
        public IActionResult GetTarefaById(Guid idTarefa)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<TarefaViewModel>(idTarefa);
            }

            _tarefaAppService.GetById(idTarefa);

            return Response<TarefaViewModel>(idTarefa);
        }

        [HttpPost("/tarefa/{idTarefa}/arquivo")]
        [AllowAnonymous]
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

        /// <summary>
        /// Excluir tarefa
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpDelete]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        [Route("tarefa")]
        public IActionResult ExcluirTarefa(Guid id)
        {
            //_tarefaAppService.Remove(id);

            return Response<TarefaViewModel>();
        }

        /// <summary>
        /// Buscar o histórico de atualizações da tarefa
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [ProducesResponseType(typeof(IEnumerable<TarefaHistoryData>), 200)]
        [HttpGet]
        [AllowAnonymous]
        [Route("tarefa/history/{id:guid}")]
        public IActionResult HistoricoDaTarefa(Guid id)
        {
            var tarefaHistoryData = _tarefaAppService.GetAllHistory(id);
            return Response<IEnumerable<TarefaHistoryData>>(tarefaHistoryData);
        }
    }
}