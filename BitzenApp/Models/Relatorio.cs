using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitzenApp.Models
{
    public class Relatorio
    {
        public List<Mes> Meses { get; set; }
        public int Tipo { get; set; }
        public string usuario { get; set; }
    }
}
