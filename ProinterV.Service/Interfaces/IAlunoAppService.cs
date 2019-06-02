using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.Interfaces
{
    public interface IAlunoAppService : IDisposable
    {
        void Register(AlunoViewModel alunoViewModel);
        IEnumerable<AlunoViewModel> GetAll();
        AlunoViewModel GetById(Guid id);
        AlunoViewModel GetByUserId(string userId);
        void Update(AlunoViewModel alunoViewModel);
        void Remove(Guid id);
        IList<AlunoHistoryData> GetAllHistory(Guid id);
    }
}
