using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class Relatorio
    {
        public List<Mes> Meses { get; private set; }
        public int Tipo { get; set; }
        public string usuario { get; set; }

        public Relatorio()
        {
            Meses = new List<Mes>();
        }

        public void setMeses(List<Mes> meses)
        {
            Meses = meses;
        }

     
       

    }
}
