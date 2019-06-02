using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ProinterV.Domain.Models
{
    public partial class GrupoTrabalho : Entity
    {
        public GrupoTrabalho(Guid id, Guid? idAluno, string nome, string descricao, DateTime prazo, string materialApoio)
        {
            Tarefa = new HashSet<Tarefa>();

            Id = id;
            IdAluno = idAluno;
            Nome = nome;
            Descricao = descricao;
            Prazo = prazo;
            MaterialApoio = materialApoio;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public Guid? IdAluno { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Prazo { get; set; }
        public string MaterialApoio { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}
