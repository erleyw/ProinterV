using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProinterV.Application.Interfaces;
using ProinterV.Application.Services;
using ProinterV.CrossCutting.Bus;
using ProinterV.CrossCutting.Identity.Authorization;
using ProinterV.CrossCutting.Identity.Models;
using ProinterV.Domain.CommandHandlers;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Core.Events;
using ProinterV.Domain.Core.Notifications;
using ProinterV.Domain.EventHandler;
using ProinterV.Domain.Events.Aluno;
using ProinterV.Domain.Events.Arquivo;
using ProinterV.Domain.Events.Grupo;
using ProinterV.Domain.Events.Tarefa;
using ProinterV.Domain.Interfaces;
using ProinterV.Infra.Data.Context;
using ProinterV.Infra.Data.EventSourcing;
using ProinterV.Infra.Data.Repository;
using ProinterV.Infra.Data.Repository.EventSourcing;
using ProinterV.Infra.Data.UoW;
using System;

namespace ProinterV.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            //services.AddScoped<IGrupoAppService, >();
            //services.AddScoped<ITarefaAppService, >();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Events
            // Aluno
            services.AddScoped<INotificationHandler<AlunoRegistradoEvent>, AlunoEventHandler>();
            services.AddScoped<INotificationHandler<AlunoAtualizadoEvent>, AlunoEventHandler>();
            services.AddScoped<INotificationHandler<AlunoRemovidoEvent>, AlunoEventHandler>();

            // Domain - Events
            //Arquivo
            services.AddScoped<INotificationHandler<ArquivoPostadoEvent>, ArquivoEventHandler>();

            // Domain - Events
            //Grupo
            services.AddScoped<INotificationHandler<GrupoRegistradoEvent>, GrupoEventHandler>();

            // Domain - Events
            //Tarefa
            services.AddScoped<INotificationHandler<TarefaRegistradaEvent>, TarefaEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegistrarAlunoCommand, bool>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarAlunoCommand, bool>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverAlunoCommand, bool>, AlunoCommandHandler>();

            // Infra - Data
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbProinterContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
