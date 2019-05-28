using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ProinterV.Domain.Models
{
    public partial class Aluno : Entity
    {
        public Aluno() { }

        public Aluno(Guid id, string nome, string login, string senha)
        {
            ArquivoTarefa = new HashSet<ArquivoTarefa>();
            GrupoTrabalho = new HashSet<GrupoTrabalho>();
            Tarefa = new HashSet<Tarefa>();

            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public virtual ICollection<ArquivoTarefa> ArquivoTarefa { get; set; }
        public virtual ICollection<GrupoTrabalho> GrupoTrabalho { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}
