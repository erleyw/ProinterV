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
    public class AlunoController : ApiController
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunoController(
            IAlunoAppService alunoAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _alunoAppService = alunoAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("aluno")]
        public IActionResult Post(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(alunoViewModel);
            }

            _alunoAppService.Register(alunoViewModel);

            return Response(alunoViewModel);
        }
    }
}