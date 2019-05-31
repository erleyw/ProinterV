using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.Repository
{
    public class GrupoTrabalhoRepository : Repository<GrupoTrabalho>, IAlunoRepository
    {
        public GrupoTrabalhoRepository(DbProinterContext context) : base(context)
        {

        }
    }
}
