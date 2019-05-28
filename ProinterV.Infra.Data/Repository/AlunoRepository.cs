using Microsoft.EntityFrameworkCore;
using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProinterV.Infra.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(DbProinterContext context) : base(context)
        {

        }

        public Aluno GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Login == email);
        }
    }
}
