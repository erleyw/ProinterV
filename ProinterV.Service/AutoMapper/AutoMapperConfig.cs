using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingAluno());
                cfg.AddProfile(new MappingAlunoGrupo());
                cfg.AddProfile(new DomainToViewModelMappingArquivoTarefa());
                cfg.AddProfile(new DomainToViewModelMappingGrupo());
                cfg.AddProfile(new DomainToViewModelMappingTarefa());
            });
        }
    }
}
