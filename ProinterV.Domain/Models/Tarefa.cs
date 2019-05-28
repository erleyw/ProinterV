using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ProinterV.Domain.Models
{
    public partial class Tarefa : Entity
    {
        public Tarefa()
        {
            ArquivoTarefa = new HashSet<ArquivoTarefa>();
        }

        public Guid IdGrupo { get; set; }
        public Guid? IdAluno { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual GrupoTrabalho IdGrupoNavigation { get; set; }
        public virtual ICollection<ArquivoTarefa> ArquivoTarefa { get; set; }
    }
}
