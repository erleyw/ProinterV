using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Application.EventSourcedNormalizers
{
    public class AlunoHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
