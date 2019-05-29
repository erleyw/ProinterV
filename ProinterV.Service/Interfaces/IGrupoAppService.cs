using ProinterV.Application.EventSourcedNormalizers;
using ProinterV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.Interfaces
{
    public interface IGrupoAppService : IDisposable
    {
        void Register(GrupoViewModel grupoViewModel);
        IEnumerable<GrupoViewModel> GetAll();
        GrupoViewModel GetById(Guid id);
        void Update(GrupoViewModel grupoViewModel);
        void Remove(Guid id);
        IList<GrupoHistoryData> GetAllHistory(Guid id);
    }
}
