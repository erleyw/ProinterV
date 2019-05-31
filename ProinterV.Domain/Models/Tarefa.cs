using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ProinterV.Domain.Models
{
    public partial class Tarefa : Entity
    {
        public Tarefa(Guid id, Guid? idAluno, string nome, string descricao)
        {
            ArquivoTarefa = new HashSet<ArquivoTarefa>();

            Id = id;
            IdAluno = IdAluno;
            Nome = nome;
            Descricao = descricao;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public Guid IdGrupo { get; private set; }
        public Guid? IdAluno { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual GrupoTrabalho IdGrupoNavigation { get; set; }
        public virtual ICollection<ArquivoTarefa> ArquivoTarefa { get; set; }
    }
}
