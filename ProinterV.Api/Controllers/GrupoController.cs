using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using System;
using System.Collections.Generic;

namespace ProinterV.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ApiController
    {
        public readonly IGrupoAppService _grupoAppService;

        public GrupoController(
            IGrupoAppService grupoAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _grupoAppService = grupoAppService;
        }

        /// <summary>
        /// Registrar uma novo grupo
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPost("/grupo")]
        [AllowAnonymous]
        public IActionResult Post(GrupoViewModel grupoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(grupoViewModel);
            }

            //_tarefaAppService.Register(GrupoViewModel);

            return Response(grupoViewModel);
        }

        /// <summary>
        /// Alterar uma tarefa
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPut("/tarefa")]
        [AllowAnonymous]
        public IActionResult Put(GrupoViewModel grupoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(grupoViewModel);
            }

            //_tarefaAppService.Register(GrupoViewModel);

            return Response(grupoViewModel);
        }

        /// <summary>
        /// Buscar todos os grupos
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet("/tarefa")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                //return Response(GrupoViewModel);
            }

            //_tarefaAppService.Register(GrupoViewModel);

            return Response();
        }

        /// <summary>
        /// Buscar tarefa pelo ID
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet("Grupo/{idGrupo}")]
        [AllowAnonymous]
        public IActionResult GetById(Guid idGrupo, Guid? idAluno)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(idGrupo);
            }

            //_tarefaAppService.Register(GrupoViewModel);

            return Response(idGrupo);
        }

        /// <summary>
        /// Excluir tarefa
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpDelete]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        [Route("grupo")]
        public IActionResult Delete(Guid id)
        {
            //_tarefaAppService.Remove(id);

            return Response();
        }

        /// <summary>
        /// Buscar o histórico de atualizações da tarefa
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [ProducesResponseType(typeof(IEnumerable<GrupoHistoryData>), 200)]
        [HttpGet]
        [AllowAnonymous]
        [Route("grupo/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var grupoHistoryData = _grupoAppService.GetAllHistory(id);
            return Response(grupoHistoryData);
        }
    }
}