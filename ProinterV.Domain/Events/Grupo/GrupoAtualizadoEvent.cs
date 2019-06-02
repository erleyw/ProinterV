using ProinterV.Domain.Core.Events;
using System;

namespace ProinterV.Domain.Events.Grupo
{
    public class GrupoAtualizadoEvent : Event
    {
        public GrupoAtualizadoEvent(Guid id, Guid? idAluno, string nome, string descricao, DateTime prazo, string materialApoio)
        {
            Id = id;
            IdAluno = idAluno;
            Nome = nome;
            Descricao = descricao;
            Prazo = prazo;
            MaterialApoio = materialApoio;
        }

        public Guid Id { get; set; }
        public Guid? IdAluno { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Prazo { get; private set; }
        public string MaterialApoio { get; private set; }
    }
}
