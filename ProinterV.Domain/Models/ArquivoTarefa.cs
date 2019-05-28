using ProinterV.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ProinterV.Domain.Models
{
    public partial class ArquivoTarefa : Entity
    {
        public Guid? IdAluno { get; set; }
        public Guid? IdTarefa { get; set; }
        public string Nome { get; set; }
        public bool? Publico { get; set; }
        public string Arquivo { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Tarefa IdTarefaNavigation { get; set; }
    }
}
