using AutoMapper;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.AutoMapper
{
    public class DomainToViewModelMappingArquivoTarefa : Profile
    {
        public DomainToViewModelMappingArquivoTarefa()
        {
            CreateMap<ArquivoTarefa, ArquivoTarefaViewModel>().ReverseMap();
        }
    }
}
