using ProinterV.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Events.Aluno
{
    public class AlunoRegistradoEvent : Event
    {
        public AlunoRegistradoEvent(Guid id, string idUsuario, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            IdUsuario = idUsuario;
            Matricula = matricula;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string IdUsuario { get; private set; }

        public string Matricula { get; private set; }
    }
}
