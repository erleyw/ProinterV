using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Api.Models;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using System;
using System.Collections.Generic;

namespace ProinterV.Api.Controllers
{
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

        [Authorize("Bearer")]
        [HttpPost("grupo")]
        [ProducesResponseType(typeof(ResponseBase<GrupoViewModel>), 200)]
        public IActionResult RegistrarGrupo(GrupoViewModel grupoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<GrupoViewModel>(grupoViewModel);
            }

            _grupoAppService.Register(grupoViewModel);

            return Response<GrupoViewModel>(grupoViewModel);
        }

        [Authorize("Bearer")]
        [HttpPut("grupo")]
        [ProducesResponseType(typeof(ResponseBase<GrupoViewModel>), 200)]
        public IActionResult AlterarGrupo(GrupoViewModel grupoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<GrupoViewModel>(grupoViewModel);
            }

            _grupoAppService.Update(grupoViewModel);

            return Response<GrupoViewModel>(grupoViewModel);
        }

        [Authorize("Bearer")]
        [HttpPost("grupo/{idGrupo}/IncluirAluno")]
        [ProducesResponseType(typeof(ResponseBase<AlunoGrupoViewModel>), 200)]
        public IActionResult IncluirAlunoNoGrupo(Guid idGrupo, [FromBody] string email)
        {
            var viewModel = new AlunoGrupoViewModel() { IdGrupo = idGrupo, EmailAluno = email };
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<AlunoGrupoViewModel>(viewModel);
            }

            _grupoAppService.IncluirAluno(viewModel);

            return Response<GrupoViewModel>(viewModel);
        }

        [Authorize("Bearer")]
        [HttpGet("grupo")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<GrupoViewModel>>), 200)]
        public IActionResult BuscarTodosGrupos()
        {
            return Response<IEnumerable<GrupoViewModel>>(_grupoAppService.GetAll());
        }

        [Authorize("Bearer")]
        [HttpGet("grupo/{id:guid}/Alunos")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<AlunoViewModel>>), 200)]
        public IActionResult BuscarTodosAlunosDoGrupo(Guid idGrupo)
        {
            return Response<IEnumerable<AlunoViewModel>>(_grupoAppService.BuscarAlunos(idGrupo));
        }

        [Authorize("Bearer")]
        [HttpGet("Grupo/{idGrupo}")]
        [ProducesResponseType(typeof(ResponseBase<GrupoViewModel>), 200)]
        public IActionResult BuscarGrupoPeloId(Guid idGrupo)
        {
            var grupoViewModel = _grupoAppService.GetById(idGrupo);

            return Response<GrupoViewModel>(grupoViewModel);
        }

        [Authorize("Bearer")]
        [HttpDelete("grupo")]
        [ProducesResponseType(typeof(ResponseBase<GrupoViewModel>), 200)]
        public IActionResult ExcluirGrupo(Guid id)
        {
            _grupoAppService.Remove(id);

            return Response<GrupoViewModel>();
        }

        [Authorize("Bearer")]
        [HttpGet("grupo/history/{id:guid}")]
        [ProducesResponseType(typeof(IEnumerable<GrupoHistoryData>), 200)]
        public IActionResult HistoricoDoGrupo(Guid id)
        {
            var grupoHistoryData = _grupoAppService.GetAllHistory(id);
            return Response<IEnumerable<GrupoHistoryData>>(grupoHistoryData);
        }
    }
}