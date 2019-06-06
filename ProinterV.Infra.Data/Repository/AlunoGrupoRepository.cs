using Microsoft.EntityFrameworkCore;
using ProinterV.Domain.Core.Models;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace ProinterV.Infra.Data.Repository
{
    public class AlunoGrupoRepository : Repository<AlunoGrupo>, IAlunoGrupoRepository
    {
        public AlunoGrupoRepository(DbProinterContext context) : base(context)
        {

        }

        public AlunoGrupo GetByGrupo(Guid alunoId, Guid grupoId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.IdAluno == alunoId && c.IdGrupo == grupoId);
        }
    }
}
