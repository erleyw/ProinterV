using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.CrossCutting.Identity.Models;
using ProinterV.CrossCutting.Identity.Models.AccountViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
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
                // User claim for write customers data
                await _userManager.AddClaimAsync(user, new Claim("Aluno", "Write"));

                await _signInManager.SignInAsync(user, false);
                //_logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }

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
    }
}