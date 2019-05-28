using ProinterV.Domain.Interfaces;
using ProinterV.Domain.Models;
using ProinterV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.Repository
{
    public class ArquivoTarefaRepository : Repository<ArquivoTarefa>, IArquivoTarefaRepository
    {
        public ArquivoTarefaRepository(DbProinterContext context) : base(context)
        {
        }
    }
}
