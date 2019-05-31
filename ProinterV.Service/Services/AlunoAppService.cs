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
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IMapper _mapper;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AlunoAppService(IMapper mapper,
                                  IAlunoRepository alunoRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _alunoRepository = alunoRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<AlunoViewModel> GetAll()
        {
            return _alunoRepository.GetAll().ProjectTo<AlunoViewModel>(_mapper.ConfigurationProvider);
        }

        public AlunoViewModel GetById(Guid id)
        {
            return _mapper.Map<AlunoViewModel>(_alunoRepository.GetById(id));
        }

        public void Register(AlunoViewModel alunoViewModel)
        {
            var registerCommand = _mapper.Map<RegistrarNovoAlunoCommand>(alunoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(AlunoViewModel alunoViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarAlunoCommand>(alunoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverAlunoCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<AlunoHistoryData> GetAllHistory(Guid id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
