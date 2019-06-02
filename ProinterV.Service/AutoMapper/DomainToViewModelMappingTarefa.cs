using AutoMapper;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.AutoMapper
{
    public class DomainToViewModelMappingTarefa : Profile
    {
        public DomainToViewModelMappingTarefa()
        {
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
            CreateMap<TarefaViewModel, TarefaCommand>().ReverseMap();
        }
    }
}
