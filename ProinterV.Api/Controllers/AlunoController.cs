using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.CrossCutting.Identity.Models;
using ProinterV.CrossCutting.Identity.Models.AccountViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProinterV.Api.Controllers
{
    [ApiController]
    public class AlunoController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IAlunoAppService _alunoAppService;

        public AlunoController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAlunoAppService alunoAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _alunoAppService = alunoAppService;
        }

        /// <summary>
        /// Registrar novo Aluno
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("aluno")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _alunoAppService.Register(new AlunoViewModel() { IdUsuario = user.Id, Matricula = model.Matricula, Nome = model.Nome});
                // User claim for write customers data
                await _userManager.AddClaimAsync(user, new Claim("Aluno", "Write"));

                await _signInManager.SignInAsync(user, false);
                //_logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }

        /// <summary>
        /// Logar
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("aluno/logar")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (!result.Succeeded)
                NotifyError(result.ToString(), "Ops. Login falhou");

            //_logger.LogInformation(1, "User logged in.");
            return Response(model);
        }

        /// <summary>
        /// Excluir Aluno
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpDelete]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        [Route("Aluno")]
        public IActionResult Delete(Guid id)
        {
            //_tarefaAppService.Remove(id);

            return Response();
        }

        /// <summary>
        /// Buscar o histórico de alterações do Aluno
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [ProducesResponseType(typeof(IEnumerable<AlunoHistoryData>), 200)]
        [HttpGet]
        [AllowAnonymous]
        [Route("aluno/history/{id:guid}")]
        public IActionResult HistoricoDoAluno(Guid id)
        {
            var tarefaHistoryData = _alunoAppService.GetAllHistory(id);
            return Response(tarefaHistoryData);
        }
    }
}