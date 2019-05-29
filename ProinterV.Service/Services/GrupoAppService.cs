using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Interfaces;
using ProinterV.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.Services
{
    public class GrupoAppService : IGrupoAppService
    {
        private readonly IMapper _mapper;
        private readonly IGrupoRepository _grupoRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public GrupoAppService(IMapper mapper,
                                  IGrupoRepository grupoRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _grupoRepository = grupoRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<GrupoViewModel> GetAll()
        {
            return _grupoRepository.GetAll().ProjectTo<GrupoViewModel>(_mapper.ConfigurationProvider);
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
