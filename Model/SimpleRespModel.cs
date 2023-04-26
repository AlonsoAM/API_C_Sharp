using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace novaltyAPI.Model
{
    public class SimpleRespModel
    {
        public int mensajeID { get; set; }
        public string mensaje { get; set; }
        public string error { get; set; }
        public int valorID { get; set; }
    }
}