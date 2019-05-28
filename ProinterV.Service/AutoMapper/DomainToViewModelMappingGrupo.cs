using AutoMapper;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.AutoMapper
{
    public class DomainToViewModelMappingGrupo : Profile
    {
        public DomainToViewModelMappingGrupo()
        {
            CreateMap<GrupoTrabalho, GrupoViewModel>().ReverseMap();
        }
    }
}
