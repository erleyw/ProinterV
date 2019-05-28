using ProinterV.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Events.Tarefa
{
    public class TarefaRegistradaEvent : Event
    {
        public TarefaRegistradaEvent(Guid id, Guid idGrupo, Guid idAluno, string nome, string descricao)
        {
            Id = id;
            IdGrupo = idGrupo;
            IdAluno = idAluno;
            Nome = nome;
            Descricao = descricao;
        }

        public Guid Id { get; set; }
        public Guid IdGrupo { get; set; }
        public Guid? IdAluno { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
