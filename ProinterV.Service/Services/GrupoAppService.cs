using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.CrossCutting.Identity.Models;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProinterV.Application.Services
{
    public class GrupoAppService : IGrupoAppService
    {
        private readonly IMapper _mapper;
        private readonly IGrupoRepository _grupoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoGrupoRepository _alunoGrupoRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;
        private readonly UserManager<ApplicationUser> _userManager;

        public GrupoAppService(IMapper mapper,
                                  IGrupoRepository grupoRepository,
                                  IAlunoRepository alunoRepository,
                                  IAlunoGrupoRepository alunoGrupoRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _grupoRepository = grupoRepository;
            _alunoRepository = alunoRepository;
            _alunoGrupoRepository = alunoGrupoRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<GrupoViewModel> GetAll()
        {
            return _grupoRepository.GetAll().ProjectTo<GrupoViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<AlunoViewModel> BuscarAlunos(Guid idGrupo)
        {
            var grupo = _grupoRepository.GetById(idGrupo);
            return _mapper.Map<IEnumerable<AlunoViewModel>>(grupo.AlunoGrupo);
        }

        public GrupoViewModel GetById(Guid id)
        {
            return _mapper.Map<GrupoViewModel>(_grupoRepository.GetById(id));
        }

        public void Register(GrupoViewModel grupoViewModel)
        {
            var registerCommand = _mapper.Map<RegistrarGrupoCommand>(grupoViewModel);
            Bus.SendCommand(registerCommand);
        }


        public void IncluirAluno(AlunoGrupoViewModel alunoGrupo)
        {
            ApplicationUser userIdentity = _userManager.FindByEmailAsync(alunoGrupo.EmailAluno).Result;
            var aluno = _alunoRepository.GetByUserId(userIdentity.Id);
            alunoGrupo.IdAluno = aluno.Id;

            var insertCommand = _mapper.Map<IncluirAlunoNoGrupoCommand>(alunoGrupo);
            Bus.SendCommand(insertCommand);
        }

        public void Update(GrupoViewModel grupoViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarGrupoCommand>(grupoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<GrupoHistoryData> GetAllHistory(Guid id)
        {
            return GrupoHistory.ToJavaScriptGrupoHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
