using ProinterV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.Interfaces
{
    public interface IGrupoAppService : IDisposable
    {
        void Registrar(GrupoViewModel alunoViewModel);
    }
}
