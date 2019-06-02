using Microsoft.EntityFrameworkCore;
using ProinterV.Domain.Core.Models;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProinterV.Infra.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(DbProinterContext context) : base(context)
        {

        }

        public Aluno GetByUserId(string userId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.IdUsuario == userId);
        }
    }
}
