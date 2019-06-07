using AutoMapper;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.AutoMapper
{
    public class MappingAlunoGrupo : Profile
    {
        public MappingAlunoGrupo()
        {
            CreateMap<AlunoGrupo, AlunoGrupoViewModel>().ReverseMap();
            CreateMap<AlunoGrupoViewModel, IncluirAlunoNoGrupoCommand>().ReverseMap();
        }
    }
}
