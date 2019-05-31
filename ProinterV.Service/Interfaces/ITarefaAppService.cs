using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.Interfaces
{
    public interface ITarefaAppService : IDisposable
    {
        void PostarArquivo(Guid IdTarefa, ArquivoTarefaViewModel arquivoTarefaViewModel);
        void Register(TarefaViewModel tarefaViewModel);
        IEnumerable<TarefaViewModel> GetAll();
        TarefaViewModel GetById(Guid id);
        void Update(TarefaViewModel customerViewModel);
        void Remove(Guid id);
        IList<TarefaHistoryData> GetAllHistory(Guid id);
    }
}
