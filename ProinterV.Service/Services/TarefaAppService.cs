using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.Interfaces;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Core.Bus;
using ProinterV.Domain.Interfaces;
using ProinterV.Infra.Data.Repository.EventSourcing;

namespace ProinterV.Application.Services
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly IMapper _mapper;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public TarefaAppService(IMapper mapper,
                                  ITarefaRepository tarefaRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _tarefaRepository = tarefaRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public void PostarArquivo(Guid IdTarefa, ArquivoTarefaViewModel arquivoTarefaViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TarefaViewModel> GetAll()
        {
            return _tarefaRepository.GetAll().ProjectTo<TarefaViewModel>(_mapper.ConfigurationProvider);
        }

        public TarefaViewModel GetById(Guid id)
        {
            return _mapper.Map<TarefaViewModel>(_tarefaRepository.GetById(id));
        }

        public void Register(TarefaViewModel tarefaViewModel)
        {
            var registerCommand = _mapper.Map<RegistrarTarefaCommand>(tarefaViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(TarefaViewModel tarefaViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarAlunoCommand>(tarefaViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<TarefaHistoryData> GetAllHistory(Guid id)
        {
            return TarefaHistory.ToJavaScriptTarefaHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
