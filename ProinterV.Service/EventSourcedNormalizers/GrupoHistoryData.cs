﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.EventSourcedNormalizers
{
    public class GrupoHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string IdAluno { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Prazo { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
