using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Models
{
    public class AlunoGrupo : Entity
    {
        public AlunoGrupo(Guid id, Guid idGrupo, Guid idAluno)
        {
            Id = id;
            IdGrupo = idGrupo;
            IdAluno = idAluno;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public Guid IdGrupo { get; set; }
        public Guid IdAluno { get; set; }

        public virtual GrupoTrabalho IdGrupoNavigation { get; set; }
        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
