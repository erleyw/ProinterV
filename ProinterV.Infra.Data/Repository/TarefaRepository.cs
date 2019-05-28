using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(DbProinterContext context) : base(context)
        {

        }
    }
}
