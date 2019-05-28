using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;

namespace ProinterV.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ApiController
    {
        private readonly IGrupoAppService _grupoAppService;

        public GrupoController(
            IGrupoAppService grupoAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _grupoAppService = grupoAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("grupo")]
        public IActionResult Post(GrupoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(alunoViewModel);
            }

            _grupoAppService.Registrar(alunoViewModel);

            return Response(alunoViewModel);
        }
    }
}