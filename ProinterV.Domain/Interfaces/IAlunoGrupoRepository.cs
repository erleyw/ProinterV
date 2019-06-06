using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Interfaces
{
    public interface IAlunoGrupoRepository : IRepository<AlunoGrupo>
    {
        AlunoGrupo GetByGrupo(Guid alunoId, Guid grupoId);
    }
}
