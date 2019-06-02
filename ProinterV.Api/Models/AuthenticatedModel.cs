using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProinterV.Api.Models
{
    public class AuthenticatedModel
    {
        public string userId { get; set; }
        public string alunoId { get; set; }
        public bool authenticated { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string accessToken { get; set; }
        public string message { get; set; }
    }
}
