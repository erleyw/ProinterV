using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ProinterV.Domain.Models
{
    public partial class Aluno : Entity
    {
        public Aluno() { }

        public Aluno(Guid id, string idUsuario, string nome, string matricula)
        {
            ArquivoTarefa = new HashSet<ArquivoTarefa>();
            GrupoTrabalho = new HashSet<GrupoTrabalho>();
            Tarefa = new HashSet<Tarefa>();

            Id = id;
            IdUsuario = idUsuario;
            Nome = nome;
            Matricula = matricula;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public string IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Matricula { get; private set; }

        public virtual ICollection<ArquivoTarefa> ArquivoTarefa { get; set; }
        public virtual ICollection<GrupoTrabalho> GrupoTrabalho { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}
