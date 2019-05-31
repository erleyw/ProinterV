using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        //Aluno GetByEmail(string email);
    }
}
