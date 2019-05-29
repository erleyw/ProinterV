using ProinterV.Domain.Core.Commands;
using System;

namespace ProinterV.Domain.Commands
{
    public abstract class GrupoCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid? IdAluno { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public DateTime Prazo { get; protected set; }
        public string MaterialApoio { get; protected set; }
    }
}