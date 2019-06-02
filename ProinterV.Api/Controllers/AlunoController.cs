using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProinterV.Api.Configurations;
using ProinterV.Api.Models;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.CrossCutting.Identity.Models;
using ProinterV.CrossCutting.Identity.Models.AccountViewModels;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
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

        [ProducesResponseType(typeof(ResponseBase<AlunoViewModel>), 200)]
        [HttpPost]
        [AllowAnonymous]
        [Route("aluno")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<RegisterViewModel>(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "CanWriteAlunoData");

                var aluno = new AlunoViewModel() { IdUsuario = user.Id, Matricula = model.Matricula, Nome = model.Nome };
                _alunoAppService.Register(aluno);

                return Response<AlunoViewModel>(model);
            }

            AddIdentityErrors(result);
            return Response<AlunoViewModel>(model);
        }

        [ProducesResponseType(typeof(ResponseBase<AuthenticatedModel>), 200)]
        [HttpPost]
        [AllowAnonymous]
        [Route("aluno/logar")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model,
            [FromServices]UserManager<ApplicationUser> userManager,
            [FromServices]SignInManager<ApplicationUser> signInManager,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response<AlunoViewModel>(model);
            }

            bool credenciaisValidas = false;
            if (model != null && !String.IsNullOrWhiteSpace(model.Email))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                var userIdentity = userManager.FindByEmailAsync(model.Email).Result;
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin = signInManager
                        .CheckPasswordSignInAsync(userIdentity, model.Password, false)
                        .Result;
                    if (resultadoLogin.Succeeded)
                    {
                        // Verifica se o usuário em questão possui
                        // a role Acesso-APIAlturas
                        credenciaisValidas = userManager.IsInRoleAsync(
                            userIdentity, "CANWRITEALUNODATA").Result;
                    }
                }
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(model.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, model.Email)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Response<AuthenticatedModel>(new AuthenticatedModel()
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                });
            }
            else
            {
                return Response<AuthenticatedModel>(new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                });
            }

            return Response<LoginViewModel>(model);
        }

        [Authorize(Policy = "Bearer")]
        [HttpDelete]
        [Route("Aluno")]
        public IActionResult Delete(Guid id)
        {
            _alunoAppService.Remove(id);

            return Response<Guid>();
        }

        [ProducesResponseType(typeof(IEnumerable<AlunoHistoryData>), 200)]
        [HttpGet]
        [AllowAnonymous]
        [Route("aluno/history/{id:guid}")]
        public IActionResult HistoricoDoAluno(Guid id)
        {
            var tarefaHistoryData = _alunoAppService.GetAllHistory(id);
            return Response<AlunoHistoryData>(tarefaHistoryData);
        }
    }
}