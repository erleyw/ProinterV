﻿using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ProinterV.Domain.Models
{
    public partial class GrupoTrabalho : Entity
    {
        public GrupoTrabalho()
        {
            Tarefa = new HashSet<Tarefa>();
        }

        public Guid IdAluno { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Prazo { get; set; }
        public string MaterialApoio { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}