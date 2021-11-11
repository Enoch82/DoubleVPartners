using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDos.Model
{
    public class CustomResponse
    {
        public string message { get; set; }
        public object data { get; set; } 
        public int success { get; set; }
    }
}
