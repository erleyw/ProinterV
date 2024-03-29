﻿using ProinterV.Domain.Core.Commands;
using System;

namespace ProinterV.Domain.Commands
{
    public abstract class AlunoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string IdUsuario { get; protected set; }

        public string Nome { get; protected set; }

        public string Matricula { get; protected set; }
    }
}