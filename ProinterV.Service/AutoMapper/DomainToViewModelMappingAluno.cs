using AutoMapper;
using ProinterV.Application.ViewModels;
using ProinterV.Domain.Commands;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.AutoMapper
{
    public class DomainToViewModelMappingAluno : Profile
    {
        public DomainToViewModelMappingAluno()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<AlunoViewModel, RegistrarAlunoCommand>().ReverseMap();
        }
    }
}
