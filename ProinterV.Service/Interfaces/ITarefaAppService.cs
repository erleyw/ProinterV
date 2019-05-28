using ProinterV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.Interfaces
{
    public interface ITarefaAppService : IDisposable
    {
        void Registrar(TarefaViewModel tarefaViewModel);
        void PostarArquivo(Guid IdTarefa, ArquivoTarefaViewModel arquivoTarefaViewModel);
    }
}
