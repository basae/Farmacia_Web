using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Farmacia_Web.Models
{
    public class RespuestaServicio<T>
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<T> Lista_Resultado { get; set; }
        public T Resultado { get; set; }
    }
}