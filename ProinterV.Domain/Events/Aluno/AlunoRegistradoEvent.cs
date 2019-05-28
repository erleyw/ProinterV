using ProinterV.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Domain.Events.Aluno
{
    public class AlunoRegistradoEvent : Event
    {
        public AlunoRegistradoEvent(Guid id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string Login { get; private set; }

        public string Senha { get; private set; }
    }
}
