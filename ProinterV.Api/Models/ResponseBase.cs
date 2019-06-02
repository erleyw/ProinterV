using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProinterV.Api.Models
{
    public class ResponseBase<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
        public IEnumerable<string> errors { get; set; }

    }
}
