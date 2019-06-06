using AutoMapper;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Commands;
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
            CreateMap<GrupoTrabalho, GrupoViewModel>().ForMember(m=>m.IdAlunoLider, opt=>opt.MapFrom(src=>src.IdAluno)).ReverseMap();
            CreateMap<GrupoViewModel, RegistrarGrupoCommand>().ConstructUsing(c => new RegistrarGrupoCommand(c.Nome, c.Descricao, c.IdAlunoLider, c.Prazo, c.MaterialApoio)).ReverseMap();
        }
    }
}
